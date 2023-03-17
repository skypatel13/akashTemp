using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using static CaseManagement.UtilityLibrary.Utility;
namespace CaseManagement.API.Controllers.Transaction.Survivor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SurvivorController : ControllerBase
    {
        private readonly ISurvivor survivor;
        private readonly ILogger<SurvivorController> logger;
        private readonly IMapper mapper;
        private readonly MyAppSettingsOptions myAppSettingsOptions;

        public SurvivorController(ISurvivor survivor, ILogger<SurvivorController> logger, IMapper mapper, IOptions<MyAppSettingsOptions> myAppSettingsOptions)
        {
            this.survivor = survivor;
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
            var result = survivor.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add([FromForm] SurvivorDTOAdd survivorDTOAdd)
        {
            string userName = User.Identity.Name;
            SurvivorDTOAddDB survivorDTOAddDB = mapper.Map<SurvivorDTOAddDB>(survivorDTOAdd);
            survivorDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            survivorDTOAddDB.CreatedBy = userName;
            survivorDTOAddDB.BirthDate = survivorDTOAddDB.BirthDate.ToLocalTime();
            survivorDTOAddDB.TraffickingDate = survivorDTOAddDB.TraffickingDate.ToLocalTime();
            if (survivorDTOAdd.ConsentFormFile != null)
            {
                survivorDTOAddDB.ConsentForm = survivorDTOAdd.ConsentFormFile.FileName;
            }
            logger.LogInformation($"|Request Argument:{survivorDTOAddDB}");
            var result = survivor.Add(survivorDTOAddDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                string survivorCode = result.SurvivorDTODetail.SurvivorCode.ToString();
                Utility.CreateSurvivorDocFolders(survivorCode);

                if (survivorDTOAdd.ConsentFormFile != null)
                {
                    var consentFormFolder = myAppSettingsOptions.ConsentForm;
                    var consentFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, survivorCode, consentFormFolder, result.SurvivorDTODetail.ConsentFormStoredAsFileName);
                    using (FileStream stream = System.IO.File.Create(consentFilePath))
                    {
                        survivorDTOAdd.ConsentFormFile.CopyTo(stream);
                    }
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(SurvivorDTOEdit survivorDTOEdit)
        {
            string userName = User.Identity.Name;
            SurvivorDTOEditDB survivorDTOEditDB = mapper.Map<SurvivorDTOEditDB>(survivorDTOEdit);
            string collectiveXML = GetXMLString(survivorDTOEdit.SurvivorCollectiveMappingDTOList);
            string sHGXML = GetXMLString(survivorDTOEdit.SurvivorSHGMappingDTOList);
            survivorDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            survivorDTOEditDB.ModifiedBy = userName;
            survivorDTOEditDB.BirthDate = survivorDTOEditDB.BirthDate.ToLocalTime();
            survivorDTOEditDB.TraffickingDate = survivorDTOEditDB.TraffickingDate.ToLocalTime();
            survivorDTOEditDB.CollectiveXML = collectiveXML;
            survivorDTOEditDB.SHGXML = sHGXML;
            logger.LogInformation($"|Request Argument:{survivorDTOEditDB}");
            var result = survivor.Edit(survivorDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int survivorCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = survivor.Delete(survivorCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = survivor.Detail(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = survivor.ChangeLog_GetById(survivorCode, userName);
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
            var result = survivor.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ProfileStatusUpdate(SurvivorProfileApproveRequestDTO survivorProfileApproveRequestDTO)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            SurvivorProfileApproveRequestDTODB survivorProfileApproveRequestDTODB = mapper.Map<SurvivorProfileApproveRequestDTODB>(survivorProfileApproveRequestDTO);
            survivorProfileApproveRequestDTODB.ProfileApprovedBy = userName;
            survivorProfileApproveRequestDTODB.ProfileApprovedByIpAddress = iPAddress;
            logger.LogInformation($"|Request Argument:{survivorProfileApproveRequestDTODB}");
            var result = survivor.ProfileStatusUpdate(survivorProfileApproveRequestDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult TafteeshStatusUpdate(SurvivorTafteeshStatusRequestDTO survivorTafteeshStatusRequestDTO)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            SurvivorTafteeshStatusRequestDTODB survivorTafteeshStatusRequestDTODB = mapper.Map<SurvivorTafteeshStatusRequestDTODB>(survivorTafteeshStatusRequestDTO);
            survivorTafteeshStatusRequestDTODB.ApprovedBy = userName;
            survivorTafteeshStatusRequestDTODB.ApprovedByIpAddress = iPAddress;
            logger.LogInformation($"|Request Argument:{survivorTafteeshStatusRequestDTODB}");
            var result = survivor.TafteeshStatusUpdate(survivorTafteeshStatusRequestDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SurvivorStatus_Insert(TafteeshStatusRequestDTO tafteeshStatusRequestDTO)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            TafteeshStatusRequestDTODB tafteeshStatusRequestDTODB = mapper.Map<TafteeshStatusRequestDTODB>(tafteeshStatusRequestDTO);
            tafteeshStatusRequestDTODB.CreatedBy = userName;
            tafteeshStatusRequestDTODB.CreatedByIpAddress = iPAddress;
            logger.LogInformation($"|Request Argument:{tafteeshStatusRequestDTODB}");
            var result = survivor.SurvivorStatus_Insert_Admin(tafteeshStatusRequestDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SurvivorStatus_Update(TafteeshStatusResponseDTO tafteeshStatusResponseDTO)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            TafteeshStatusResponseDTODB tafteeshStatusResponseDTODB = mapper.Map<TafteeshStatusResponseDTODB>(tafteeshStatusResponseDTO);
            tafteeshStatusResponseDTODB.CreatedBy = userName;
            tafteeshStatusResponseDTODB.CreatedByIpAddress = iPAddress;
            logger.LogInformation($"|Request Argument:{tafteeshStatusResponseDTODB}");
            var result = survivor.SurvivorStatus_Update_Admin(tafteeshStatusResponseDTODB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SurvivorStatus_List(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = survivor.SurvivorStatus_ListByCode(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SurvivorProfileReport(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = survivor.SurvivorProfileDetailsByCode(survivorCode, userName);
            if (result.SurvivorBasicDetailsDTO.PhotoStoredAsFileName != null)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                var photoFolder = myAppSettingsOptions.SpecificDoc;
                var photoFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.SurvivorBasicDetailsDTO.SurvivorCode.ToString(), photoFolder, result.SurvivorBasicDetailsDTO.PhotoStoredAsFileName);
                if (System.IO.File.Exists(photoFilePath))
                {
                    Byte[] bytes = System.IO.File.ReadAllBytes(photoFilePath);
                    String file = Convert.ToBase64String(bytes);
                    result.SurvivorBasicDetailsDTO.ProfilePhoto = file;
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}
