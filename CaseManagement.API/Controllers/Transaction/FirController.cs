using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Transaction
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class FirController : ControllerBase
    {
        private readonly IFir fir;
        private readonly ILogger<FirController> logger;
        private readonly IMapper mapper;
        private readonly MyAppSettingsOptions myAppSettingsOptions;

        public FirController(IFir fir, ILogger<FirController> logger, IMapper mapper, IOptions<MyAppSettingsOptions> myAppSettingsOptions)
        {
            this.fir = fir;
            this.logger = logger;
            this.mapper = mapper;
            this.myAppSettingsOptions = myAppSettingsOptions.Value;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = fir.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add([FromForm] FirDTOAdd firDTOAdd)
        {
            string userName = User.Identity.Name;
            FirDTOAddDB firDTOAddDB = mapper.Map<FirDTOAddDB>(firDTOAdd);
            List<FirActSectionMappingDTOList> FirAssignedActSectionDTOList = JsonConvert.DeserializeObject<List<FirActSectionMappingDTOList>>(firDTOAdd.FirActSectionMappingDTOLists);
            List<FirAccusedMappingDTOList> FirAccusedMappingDTOList = JsonConvert.DeserializeObject<List<FirAccusedMappingDTOList>>(firDTOAdd.FirAccusedMappingDTOList);
            string accusedXML = GetXMLString(FirAccusedMappingDTOList);
            string actSectionXML = GetXMLString(FirAssignedActSectionDTOList);
            firDTOAddDB.ActSectionData = actSectionXML;
            firDTOAddDB.TraffickerData = accusedXML;
            firDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            firDTOAddDB.CreatedBy = userName;
            firDTOAddDB.FIRCopy = (firDTOAdd.FIRCopy?.FileName);
            firDTOAddDB.GDCopy = (firDTOAdd.GDCopy?.FileName);
            logger.LogInformation($"|Request Argument:{firDTOAddDB}");
            var result = fir.Add(firDTOAddDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (firDTOAdd.FIRCopy != null)
                {
                    var firFolder = myAppSettingsOptions.FIR;
                    var firFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.FirDTODetail.SurvivorCode.ToString(), firFolder, result.FirDTODetail.FIRCopyStoredAs);
                    using FileStream stream = System.IO.File.Create(firFilePath);
                    firDTOAdd.FIRCopy.CopyTo(stream);
                }
                if (firDTOAdd.GDCopy != null)
                {
                    var gdFolder = myAppSettingsOptions.GD;
                    var gdFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.FirDTODetail.SurvivorCode.ToString(), gdFolder, result.FirDTODetail.GDCopyStoredAs);
                    using FileStream stream = System.IO.File.Create(gdFilePath);
                    firDTOAdd.GDCopy.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit([FromForm] FirDTOEdit firDTOEdit)
        {
            string userName = User.Identity.Name;
            FirDTOEditDB firDTOEditDB = mapper.Map<FirDTOEditDB>(firDTOEdit);
            List<FirActSectionMappingDTOList> FirAssignedActSectionDTOList = JsonConvert.DeserializeObject<List<FirActSectionMappingDTOList>>(firDTOEdit.FirActSectionMappingDTOLists);
            List<FirAccusedMappingDTOList> FirAccusedMappingDTOList = JsonConvert.DeserializeObject<List<FirAccusedMappingDTOList>>(firDTOEdit.FirAccusedMappingDTOList);
            string accusedXML = GetXMLString(FirAccusedMappingDTOList);
            string actSectionXML = GetXMLString(FirAssignedActSectionDTOList);
            firDTOEditDB.ActSectionData = actSectionXML;
            firDTOEditDB.TraffickerData = accusedXML;
            firDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            firDTOEditDB.ModifiedBy = userName;
            if (firDTOEdit.FIRCopy != null)
            {
                firDTOEditDB.FIRCopy = firDTOEdit.FIRCopy.FileName;
            }
            else
            {
                firDTOEditDB.FIRCopy = firDTOEdit.FIRCopyStoredAs;
            }
            if (firDTOEdit.GDCopy != null)
            {
                firDTOEditDB.GDCopy = firDTOEdit.GDCopy.FileName;
            }
            else
            {
                firDTOEditDB.GDCopy = firDTOEdit.GDCopyStoredAs;
            }
            logger.LogInformation($"|Request Argument:{firDTOEditDB}");
            var result = fir.Edit(firDTOEditDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (firDTOEdit.FIRCopy != null)
                {
                    var firFolder = myAppSettingsOptions.FIR;
                    var firFilePAth = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.FirDTODetail.SurvivorCode.ToString(), firFolder, result.FirDTODetail.FIRCopyStoredAs);
                    using FileStream stream = System.IO.File.Create(firFilePAth);
                    firDTOEdit.FIRCopy.CopyTo(stream);
                }
                if (firDTOEdit.GDCopy != null)
                {
                    var gdFolder = myAppSettingsOptions.GD;
                    var gdFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.FirDTODetail.SurvivorCode.ToString(), gdFolder, result.FirDTODetail.GDCopyStoredAs);
                    using FileStream stream = System.IO.File.Create(gdFilePath);
                    firDTOEdit.GDCopy.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{firCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int firCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},FirCode:{firCode}");
            var result = fir.Delete(firCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{firCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int firCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},FirCode:{firCode}");
            var result = fir.Detail(firCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{firCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int firCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},FirCode:{firCode}");
            var result = fir.ChangeLog_GetById(firCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{firCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetFirAccusedList(int firCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},FirCode:{firCode}");
            FirAccusedDTOResponse result = new FirAccusedDTOResponse();
            if (firCode == 0)
            {
                result = fir.GetFirAccusedList(0, userName);
            }
            else
            {
                result = fir.GetFirAccusedList(firCode, userName);
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{firCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetFirActSectionList(int firCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},FirCode:{firCode}");
            FirActSectionDTOResponse result = new FirActSectionDTOResponse();
            if (firCode == 0)
            {
                result = fir.GetFirActSectionList(0, userName);
            }
            else
            {
                result = fir.GetFirActSectionList(firCode, userName);
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = fir.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ListBySurvivor(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = fir.ListBySurvivor(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedListBySurvivor(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = fir.DeletedListBySurvivor(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ActSectionAdd(FirActSectionRequestDTO firActSectionRequestDTO)
        {
            string userName = User.Identity.Name;//"Man@1";
            FirActSectionRequestDTODB firActSectionRequestDTODB = mapper.Map<FirActSectionRequestDTODB>(firActSectionRequestDTO);
            firActSectionRequestDTODB.AddedOn = firActSectionRequestDTO.AddedOn.ToLocalTime();
            string actSectionData = GetXMLString(firActSectionRequestDTO.FirActSectionMappingDTOList);
            firActSectionRequestDTODB.CreatedByIpAddress = GetIPAddress(Request);
            firActSectionRequestDTODB.CreatedBy = userName;
            firActSectionRequestDTODB.ActSectionData = actSectionData;
            logger.LogInformation($"|Request {firActSectionRequestDTODB}");
            var result = fir.ActSectionAdd(firActSectionRequestDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{firCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult BasicDetail(int firCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},FirCode:{firCode}");
            var result = fir.BasicDetail(firCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{firCode:int}/{survivorCode}/{firCopy}/{gdCopy}")]
        public IActionResult DownloadFile(int firCode, string survivorCode, string firCopy, string gdCopy)
        {
            logger.LogInformation($"firCode:{firCode}, survivorCode: {survivorCode}, FIR FileName:{firCopy}, GD FileName:{gdCopy}");
            var survivorFolder = myAppSettingsOptions.Survivor;
            var contentType = "APPLICATION/octet-stream";
            if (firCopy != "null")
            {
                var firFolder = myAppSettingsOptions.FIR;
                var firFilePAth = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, survivorCode, firFolder, firCopy);
                if (System.IO.File.Exists(firFilePAth))
                {
                    var filepdf = System.IO.File.ReadAllBytes(firFilePAth);
                    return File(filepdf, contentType, firCopy);
                }
                else
                {
                    return NotFound();
                }
            }
            if (gdCopy != "null")
            {
                var gdFolder = myAppSettingsOptions.GD;
                var gdFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, survivorCode, gdFolder, gdCopy);
                if (System.IO.File.Exists(gdFilePath))
                {
                    var filepdf = System.IO.File.ReadAllBytes(gdFilePath);
                    return File(filepdf, contentType, gdCopy);
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }
        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetPoliceStationBySourceDestination(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = fir.GetPoliceStationBySourceDestination(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

    }
}