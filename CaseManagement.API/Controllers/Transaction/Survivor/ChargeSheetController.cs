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

namespace CaseManagement.API.Controllers.Transaction.Survivor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ChargeSheetController : ControllerBase
    {
        private readonly IChargeSheet chargeSheet;
        private readonly ILogger<ChargeSheetController> logger;
        private readonly IMapper mapper;
        private readonly MyAppSettingsOptions myAppSettingsOptions;

        public ChargeSheetController(IChargeSheet chargeSheet, ILogger<ChargeSheetController> logger, IMapper mapper, IOptions<MyAppSettingsOptions> myAppSettingsOptions)
        {
            this.chargeSheet = chargeSheet;
            this.logger = logger;
            this.mapper = mapper;
            this.myAppSettingsOptions = myAppSettingsOptions.Value;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{survivorCode:int}")]
        public IActionResult List(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = chargeSheet.List(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = chargeSheet.DeletedList(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{chargesheetCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int chargesheetCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},Chargesheet Code:{chargesheetCode}");
            var result = chargeSheet.ChangeLog_GetById(chargesheetCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{investigationCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Chargesheet_Header(int investigationCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},InvestigationCode:{investigationCode}");
            var result = chargeSheet.Chargesheet_Header_GetByCode(investigationCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{chargesheetCode:int}/{investigationCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Chargesheet_AccusedList(int chargesheetCode, int investigationCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},InvestigationCode:{investigationCode},ChargesheetCode:{chargesheetCode}");
            var result = chargeSheet.Chargesheet_Accused_List(chargesheetCode, investigationCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{chargesheetCode:int}/{investigationCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Chargesheet_SectionList(int chargesheetCode, int investigationCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},InvestigationCode:{investigationCode},ChargesheetCode:{chargesheetCode}");
            var result = chargeSheet.Chargesheet_Section_List(chargesheetCode, investigationCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add([FromForm] ChargeSheetDTOAdd ChargeSheetDTOAdd)
        {
            string userName = User.Identity.Name;
            ChargeSheetDTOAddDB ChargeSheetDTOAddDB = mapper.Map<ChargeSheetDTOAddDB>(ChargeSheetDTOAdd);
            List<ChargeSheetActSectionMappingDTOList> chargeSheetAssignedActSectionDTOList = JsonConvert.DeserializeObject<List<ChargeSheetActSectionMappingDTOList>>(ChargeSheetDTOAdd.ChargeSheetActSectionMappingDTOList);
            List<ChargeSheetAccusedMappingDTOList> chargeSheetAccusedMappingDTOList = JsonConvert.DeserializeObject<List<ChargeSheetAccusedMappingDTOList>>(ChargeSheetDTOAdd.ChargeSheetAccusedMappingDTOList);
            string accusedXML = GetXMLString(chargeSheetAccusedMappingDTOList);
            string actSectionXML = GetXMLString(chargeSheetAssignedActSectionDTOList);
            ChargeSheetDTOAddDB.ActSectionData = actSectionXML;
            ChargeSheetDTOAddDB.TraffickerData = accusedXML;
            ChargeSheetDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            ChargeSheetDTOAddDB.CreatedBy = userName;
            ChargeSheetDTOAddDB.ChargeSheetCopy = (ChargeSheetDTOAdd.ChargeSheetCopy?.FileName);
            logger.LogInformation($"|Request Argument:{ChargeSheetDTOAddDB}");
            var result = chargeSheet.Add(ChargeSheetDTOAddDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (ChargeSheetDTOAdd.ChargeSheetCopy != null)
                {
                    var ChargeSheetFolder = myAppSettingsOptions.ChargeSheet;
                    var ChargeSheetFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.ChargeSheetDTODetail.SurvivorCode.ToString(), ChargeSheetFolder, result.ChargeSheetDTODetail.ChargeSheetCopyStoredAs);
                    using FileStream stream = System.IO.File.Create(ChargeSheetFilePath);
                    ChargeSheetDTOAdd.ChargeSheetCopy.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{chargeSheetCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int chargeSheetCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},ChargeSheetCode:{chargeSheetCode}");
            var result = chargeSheet.Detail(chargeSheetCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit([FromForm] ChargeSheetDTOEdit chargeSheetDTOEdit)
        {
            string userName = User.Identity.Name;
            ChargeSheetDTOEditDB chargeSheetDTOEditDB = mapper.Map<ChargeSheetDTOEditDB>(chargeSheetDTOEdit);
            List<ChargeSheetActSectionMappingDTOList> ChargeSheetAssignedActSectionDTOList = JsonConvert.DeserializeObject<List<ChargeSheetActSectionMappingDTOList>>(chargeSheetDTOEdit.ChargeSheetActSectionMappingDTOList);
            List<ChargeSheetAccusedMappingDTOList> ChargeSheetAccusedMappingDTOList = JsonConvert.DeserializeObject<List<ChargeSheetAccusedMappingDTOList>>(chargeSheetDTOEdit.ChargeSheetAccusedMappingDTOList);
            string accusedXML = GetXMLString(ChargeSheetAccusedMappingDTOList);
            string actSectionXML = GetXMLString(ChargeSheetAssignedActSectionDTOList);
            chargeSheetDTOEditDB.ActSectionData = actSectionXML;
            chargeSheetDTOEditDB.TraffickerData = accusedXML;
            chargeSheetDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            chargeSheetDTOEditDB.ModifiedBy = userName;
            if (chargeSheetDTOEdit.ChargeSheetCopy != null)
            {
                chargeSheetDTOEditDB.ChargeSheetCopy = chargeSheetDTOEdit.ChargeSheetCopy.FileName;
            }
            else
            {
                chargeSheetDTOEditDB.ChargeSheetCopy = chargeSheetDTOEdit.ChargeSheetCopyStoredAs;
            }
            logger.LogInformation($"|Request Argument:{chargeSheetDTOEditDB}");
            var result = chargeSheet.Edit(chargeSheetDTOEditDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (chargeSheetDTOEdit.ChargeSheetCopy != null)
                {
                    var chargeSheetFolder = myAppSettingsOptions.ChargeSheet;
                    var chargeSheetFilePAth = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.ChargeSheetDTODetail.SurvivorCode.ToString(), chargeSheetFolder, result.ChargeSheetDTODetail.ChargeSheetCopyStoredAs);
                    using FileStream stream = System.IO.File.Create(chargeSheetFilePAth);
                    chargeSheetDTOEdit.ChargeSheetCopy.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{chargeSheetCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int chargeSheetCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},ChargeSheetCode:{chargeSheetCode}");
            var result = chargeSheet.Delete(chargeSheetCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{chargeSheetCode:int}/{survivorCode}/{chargeSheetCopy}")]
        public IActionResult DownloadFile(int chargeSheetCode, string survivorCode, string chargeSheetCopy)
        {
            logger.LogInformation($"ChargeSheet Code:{chargeSheetCode}, Survivor Code: {survivorCode}, ChargeSheet FileName:{chargeSheetCopy}");
            var survivorFolder = myAppSettingsOptions.Survivor;
            var contentType = "APPLICATION/octet-stream";
            if (chargeSheetCopy != "null")
            {
                var chargeSheetFolder = myAppSettingsOptions.ChargeSheet;
                var firFilePAth = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, survivorCode, chargeSheetFolder, chargeSheetCopy);
                if (System.IO.File.Exists(firFilePAth))
                {
                    var filepdf = System.IO.File.ReadAllBytes(firFilePAth);
                    return File(filepdf, contentType, chargeSheetCopy);
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }
    }
}
