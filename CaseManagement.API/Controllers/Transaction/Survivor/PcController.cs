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
using static CaseManagement.UtilityLibrary.EnumType;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Transaction.Survivor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PcController : ControllerBase
    {
        private readonly IPc pc;
        private readonly ILogger<VcController> logger;
        private readonly IMapper mapper;
        private readonly MyAppSettingsOptions myAppSettingsOptions;

        public PcController(IPc pc, ILogger<VcController> logger, IMapper mapper, IOptions<MyAppSettingsOptions> myAppSettingsOptions)
        {
            this.pc = pc;
            this.logger = logger;
            this.mapper = mapper;
            this.myAppSettingsOptions = myAppSettingsOptions.Value;
        }

        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = pc.List(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult PCApplicationAdd([FromForm] PcApplicationDTOAdd pcDTOAdd)
        {
            string userName = User.Identity.Name;
            PcApplicationDTOAddDB pcDTOAddDB = mapper.Map<PcApplicationDTOAddDB>(pcDTOAdd);
            pcDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            pcDTOAddDB.CreatedBy = userName;
            List<PCWhyMappingDTOAdd> pCWhyMappingDTOAdd = JsonConvert.DeserializeObject<List<PCWhyMappingDTOAdd>>(pcDTOAdd.PCWhyMappingDTOAdd);
            pcDTOAddDB.WhyPCData = GetXMLString(pCWhyMappingDTOAdd);
            pcDTOAddDB.ReferenceDocument = pcDTOAdd.ReferenceDocument?.FileName;
            logger.LogInformation($"|Request Argument:{pcDTOAddDB}");
            var result = pc.PCApplicationAdd(pcDTOAddDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (pcDTOAdd.ReferenceDocument != null)
                {
                    var pcFolder = myAppSettingsOptions.PC;
                    var pcApplicationFolder = myAppSettingsOptions.PCApplication;
                    var pcFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.PcDTODetail.SurvivorCode.ToString(), pcFolder, pcApplicationFolder, result.PcDTODetail.ReferenceDocumentStoredAs);
                    using (FileStream stream = System.IO.File.Create(pcFilePath))
                    {
                        pcDTOAdd.ReferenceDocument.CopyTo(stream);
                    }
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        /// <summary>
        /// To update details of PC application, fields related to PC application (except order).
        /// </summary>
        /// <param name="pcDTOBasicEdit"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult PCApplicationEdit([FromForm] PcApplicationDTOEdit pcDTOBasicEdit)
        {
            string userName = User.Identity.Name;
            PcApplicationDTOEditDB pcDTOBasicEditDB = mapper.Map<PcApplicationDTOEditDB>(pcDTOBasicEdit);
            pcDTOBasicEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            pcDTOBasicEditDB.ModifiedBy = userName;
            pcDTOBasicEditDB.ReferenceDocument = pcDTOBasicEdit.ReferenceDocument?.FileName;
            List<PCWhyMappingDTOAdd> pCWhyMappingDTOAdd = JsonConvert.DeserializeObject<List<PCWhyMappingDTOAdd>>(pcDTOBasicEdit.PCWhyMappingDTOAdd);
            pcDTOBasicEditDB.WhyPCData = GetXMLString(pCWhyMappingDTOAdd);
            logger.LogInformation($"|Request Argument:{pcDTOBasicEditDB}");
            var result = pc.PCApplicationEdit(pcDTOBasicEditDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (pcDTOBasicEdit.ReferenceDocument != null)
                {
                    var pcFolder = myAppSettingsOptions.PC;
                    var pcApplicationFolder = myAppSettingsOptions.PCApplication;
                    var firFilePAth = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.PcDTODetail.SurvivorCode.ToString(), pcFolder, pcApplicationFolder, result.PcDTODetail.ReferenceDocumentStoredAs);
                    using FileStream stream = System.IO.File.Create(firFilePAth);
                    pcDTOBasicEdit.ReferenceDocument.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult OrderUpdate([FromForm] PcDTOOrderEdit pcDTOStatusEdit)
        {
            string userName = User.Identity.Name;
            PcDTOOrderEditDB pcDTOStatusEditDB = mapper.Map<PcDTOOrderEditDB>(pcDTOStatusEdit);
            pcDTOStatusEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            pcDTOStatusEditDB.ModifiedBy = userName;
            pcDTOStatusEditDB.OrderDocument = pcDTOStatusEdit.OrderDocument?.FileName;
            logger.LogInformation($"|Request Argument:{pcDTOStatusEditDB}");
            var result = pc.OrderUpdate(pcDTOStatusEditDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (pcDTOStatusEdit.OrderDocument != null)
                {
                    var pcFolder = myAppSettingsOptions.PC;
                    var pcOrderFolder = myAppSettingsOptions.PCOrder;
                    var firFilePAth = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.PcDTODetail.SurvivorCode.ToString(), pcFolder, pcOrderFolder, result.PcDTODetail.OrderDocumentStoredAs);
                    using FileStream stream = System.IO.File.Create(firFilePAth);
                    pcDTOStatusEdit.OrderDocument.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{pcCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int pcCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},PcCode:{pcCode}");
            var result = pc.Delete(pcCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{pcCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int pcCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},PcCode:{pcCode}");
            var result = pc.Detail(pcCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{pcCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int pcCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},PcCode:{pcCode}");
            var result = pc.ChangeLog_GetById(pcCode, userName);
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
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = pc.DeletedList(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{pcCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult EscalationList(int? pcCode = 0)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},PcCode:{pcCode}");
            var result = pc.EscalationList(userName, pcCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult EscalationAdd([FromForm] PcEscalationDTOAdd pcDTOAdd)
        {
            string userName = User.Identity.Name;
            PcEscalationDTOAddDB PcEscalationDTOAddDB = mapper.Map<PcEscalationDTOAddDB>(pcDTOAdd);
            PcEscalationDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            PcEscalationDTOAddDB.CreatedBy = userName;
            PcEscalationDTOAddDB.ReferenceDocument = pcDTOAdd.ReferenceDocument?.FileName;
            List<PCWhyMappingDTOAdd> pCWhyMappingDTOAdd = JsonConvert.DeserializeObject<List<PCWhyMappingDTOAdd>>(pcDTOAdd.PCWhyMappingDTOAdd);
            PcEscalationDTOAddDB.WhyPCData = GetXMLString(pCWhyMappingDTOAdd);
            logger.LogInformation($"|Request Argument:{PcEscalationDTOAddDB}");
            var result = pc.EscalationAdd(PcEscalationDTOAddDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (pcDTOAdd.ReferenceDocument != null)
                {
                    var pcFolder = myAppSettingsOptions.PC;
                    var pcApplicationFolder = myAppSettingsOptions.PCApplication;
                    var pcFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.PcDTODetail.SurvivorCode.ToString(), pcFolder, pcApplicationFolder, result.PcDTODetail.ReferenceDocumentStoredAs);
                    using (FileStream stream = System.IO.File.Create(pcFilePath))
                    {
                        pcDTOAdd.ReferenceDocument.CopyTo(stream);
                    }
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ConcludeUpdate(PcConcludeDTOAdd pcConcludeDTOAdd)
        {
            string userName = User.Identity.Name;
            PcConcludeDTOAddDB pcConcludeDTOAddDB = mapper.Map<PcConcludeDTOAddDB>(pcConcludeDTOAdd);
            pcConcludeDTOAddDB.ConcludedDate = pcConcludeDTOAdd.ConcludedDate.ToLocalTime();
            pcConcludeDTOAddDB.ConcludedByIpAddress = GetIPAddress(Request);
            pcConcludeDTOAddDB.ConcludedBy = userName;
            logger.LogInformation($"|Request Argument:{pcConcludeDTOAdd}");
            var result = pc.concludedAdd(pcConcludeDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{pcCode:int}/{survivorCode}/{documentType}/{documentName}")]
        public IActionResult DownloadFile(int pcCode, string survivorCode, int documentType, string documentName)
        {
            //Docuement Type : 5 = PCApplication , 6 = PCOrder
            logger.LogInformation($"PcCode:{pcCode}, survivorCode: {survivorCode}, Document FileName:{documentName},DocumentType:{documentType}");
            var pcFolder = myAppSettingsOptions.PC;
            var survivorFolder = myAppSettingsOptions.Survivor;
            var contentType = "APPLICATION/octet-stream";
            if (documentType == (int)DocumentType.PCAPPLICATION)
            {
                var pcApplicationFolder = myAppSettingsOptions.PCApplication;
                var pcFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, survivorCode, pcFolder, pcApplicationFolder, documentName);
                if (System.IO.File.Exists(pcFilePath))
                {
                    var filepdf = System.IO.File.ReadAllBytes(pcFilePath);
                    return File(filepdf, contentType, documentName);
                }
                else
                {
                    return NotFound();
                }
            }
            else if (documentType == (int)DocumentType.PCORDER)
            {
                var pcOrderFolder = myAppSettingsOptions.PCOrder;
                var pcFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, survivorCode, pcFolder, pcOrderFolder, documentName);
                if (System.IO.File.Exists(pcFilePath))
                {
                    var filepdf = System.IO.File.ReadAllBytes(pcFilePath);
                    return File(filepdf, contentType, documentName);
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