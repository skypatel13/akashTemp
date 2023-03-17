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
using System.IO;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Transaction.Survivor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class VcController : ControllerBase
    {
        private readonly IVc vc;
        private readonly ILogger<VcController> logger;
        private readonly IMapper mapper;
        private readonly MyAppSettingsOptions myAppSettingsOptions;

        public VcController(IVc vc, ILogger<VcController> logger, IMapper mapper, IOptions<MyAppSettingsOptions> myAppSettingsOptions)
        {
            this.vc = vc;
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
            var result = vc.List(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult VCApplicationAdd([FromForm] VcApplicationDTOAdd vcDTOAdd)
        {
            string userName = User.Identity.Name;
            VcApplicationDTOAddDB vcDTOAddDB = mapper.Map<VcApplicationDTOAddDB>(vcDTOAdd);
            vcDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            vcDTOAddDB.CreatedBy = userName;
            if (vcDTOAdd.ReferenceDocument != null)
            {
                vcDTOAddDB.ReferenceDocument = vcDTOAdd.ReferenceDocument.FileName;
            }
            logger.LogInformation($"|Request Argument:{vcDTOAddDB}");
            var result = vc.VCApplicationAdd(vcDTOAddDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (vcDTOAdd.ReferenceDocument != null)
                {
                    var vcFolder = myAppSettingsOptions.VC;
                    var vcApplicationFolder = myAppSettingsOptions.VCApplication;
                    var vcFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.VcDTODetail.SurvivorCode.ToString(), vcFolder, vcApplicationFolder, result.VcDTODetail.ReferenceDocumentStoredAs);
                    using (FileStream stream = System.IO.File.Create(vcFilePath))
                    {
                        vcDTOAdd.ReferenceDocument.CopyTo(stream);
                    }
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        /// <summary>
        /// To update details of VC application, fields related to VC application (except order). 
        /// </summary>
        /// <param name="vcDTOBasicEdit"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult VCApplicationEdit([FromForm] VcApplicationDTOEdit vcDTOBasicEdit)
        {
            string userName = User.Identity.Name;
            VcApplicationDTOEditDB vcDTOBasicEditDB = mapper.Map<VcApplicationDTOEditDB>(vcDTOBasicEdit);
            vcDTOBasicEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            vcDTOBasicEditDB.ModifiedBy = userName;
            //vcDTOBasicEditDB.ReferenceDocument = vcDTOBasicEdit.ReferenceDocument != null ? vcDTOBasicEdit.ReferenceDocument.FileName : vcDTOBasicEdit.ReferenceDocumentStoredAs;
            if (vcDTOBasicEdit.ReferenceDocument != null)
            {
                vcDTOBasicEditDB.ReferenceDocument = vcDTOBasicEdit.ReferenceDocument.FileName;
            }
            else
            {
                vcDTOBasicEditDB.ReferenceDocument = vcDTOBasicEdit.ReferenceDocumentStoredAs;
            }
            logger.LogInformation($"|Request Argument:{vcDTOBasicEditDB}");
            var result = vc.VCApplicationEdit(vcDTOBasicEditDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (vcDTOBasicEdit.ReferenceDocument != null)
                {
                    var vcFolder = myAppSettingsOptions.VC;
                    var vcApplicationFolder = myAppSettingsOptions.VCApplication;
                    var firFilePAth = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.VcDTODetail.SurvivorCode.ToString(), vcFolder, vcApplicationFolder, result.VcDTODetail.ReferenceDocumentStoredAs);
                    using FileStream stream = System.IO.File.Create(firFilePAth);
                    vcDTOBasicEdit.ReferenceDocument.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult OrderUpdate([FromForm] VcDTOOrderEdit vcDTOStatusEdit)
        {
            string userName = User.Identity.Name;
            VcDTOOrderEditDB vcDTOStatusEditDB = mapper.Map<VcDTOOrderEditDB>(vcDTOStatusEdit);
            vcDTOStatusEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            vcDTOStatusEditDB.ModifiedBy = userName;
            if (vcDTOStatusEdit.OrderDocument != null)
            {
                vcDTOStatusEditDB.OrderDocument = vcDTOStatusEdit.OrderDocument.FileName;
            }
            logger.LogInformation($"|Request Argument:{vcDTOStatusEditDB}");
            var result = vc.OrderUpdate(vcDTOStatusEditDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (vcDTOStatusEdit.OrderDocument != null)
                {
                    var vcFolder = myAppSettingsOptions.VC;
                    var vcOrderFolder = myAppSettingsOptions.VCOrder;
                    var firFilePAth = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.VcDTODetail.SurvivorCode.ToString(), vcFolder, vcOrderFolder, result.VcDTODetail.OrderDocumentStoredAs);
                    using FileStream stream = System.IO.File.Create(firFilePAth);
                    vcDTOStatusEdit.OrderDocument.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{vcCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int vcCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},VcCode:{vcCode}");
            var result = vc.Delete(vcCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{vcCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int vcCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},VcCode:{vcCode}");
            var result = vc.Detail(vcCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{vcCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int vcCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},VcCode:{vcCode}");
            var result = vc.ChangeLog_GetById(vcCode, userName);
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
            var result = vc.DeletedList(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{vcCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult EscalationList(int? vcCode = 0)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},VcCode:{vcCode}");
            var result = vc.EscalationList(userName, vcCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult EscalationAdd([FromForm] VcEscalationDTOAdd vcDTOAdd)
        {
            string userName = User.Identity.Name;
            VcEscalationDTOAddDB VcEscalationDTOAddDB = mapper.Map<VcEscalationDTOAddDB>(vcDTOAdd);
            VcEscalationDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            VcEscalationDTOAddDB.CreatedBy = userName;
            if (vcDTOAdd.ReferenceDocument != null)
            {
                VcEscalationDTOAddDB.ReferenceDocument = vcDTOAdd.ReferenceDocument.FileName;
            }
            logger.LogInformation($"|Request Argument:{VcEscalationDTOAddDB}");
            var result = vc.EscalationAdd(VcEscalationDTOAddDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (vcDTOAdd.ReferenceDocument != null)
                {
                    var vcFolder = myAppSettingsOptions.VC;
                    var vcApplicationFolder = myAppSettingsOptions.VCApplication;
                    var vcFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.VcDTODetail.SurvivorCode.ToString(), vcFolder, vcApplicationFolder, result.VcDTODetail.ReferenceDocumentStoredAs);
                    using (FileStream stream = System.IO.File.Create(vcFilePath))
                    {
                        vcDTOAdd.ReferenceDocument.CopyTo(stream);
                    }
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ConcludeUpdate(VCConcludeDTOAdd vCConcludeDTOAdd)
        {
            string userName = User.Identity.Name;
            VCConcludeDTOAddDB vCConcludeDTOAddDB = mapper.Map<VCConcludeDTOAddDB>(vCConcludeDTOAdd);
            vCConcludeDTOAddDB.ConcludedDate = vCConcludeDTOAdd.ConcludedDate.ToLocalTime();
            vCConcludeDTOAddDB.concludedByIpAddress = GetIPAddress(Request);
            vCConcludeDTOAddDB.concludedBy = userName;
            logger.LogInformation($"|Request Argument:{vCConcludeDTOAddDB}");
            var result = vc.concludedAdd(vCConcludeDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult BankDetail(VCBankDetailDTOAdd vCBankDetailDTOAdd)
        {
            string userName = User.Identity.Name;
            VcBankDetailDTOAddDB vcBankDetailDTOAddDB = mapper.Map<VcBankDetailDTOAddDB>(vCBankDetailDTOAdd);
            vcBankDetailDTOAddDB.AmountReceivedDate = vCBankDetailDTOAdd.AmountReceivedDate?.ToLocalTime();
            vcBankDetailDTOAddDB.ModifiedByIpAddress = GetIPAddress(Request);
            vcBankDetailDTOAddDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{vcBankDetailDTOAddDB}");
            var result = vc.BankDetailUpdate(vcBankDetailDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{vcCode:int}/{survivorCode}/{referenceDocument}/{orderDocument}")]
        public IActionResult DownloadFile(int vcCode, string survivorCode, string referenceDocument, string orderDocument)
        {
            logger.LogInformation($"vcCode:{vcCode}, survivorCode: {survivorCode} ReferenceDocument FileName:{referenceDocument} OrderDocument FileName:{orderDocument}");
            var survivorFolder = myAppSettingsOptions.Survivor;
            var contentType = "APPLICATION/octet-stream";
            if (referenceDocument != "null")
            {
                var vcFolder = myAppSettingsOptions.VC;
                var vcApplicationFolder = myAppSettingsOptions.VCApplication;
                var vcFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, survivorCode, vcFolder, vcApplicationFolder, referenceDocument);
                if (System.IO.File.Exists(vcFilePath))
                {
                    var filepdf = System.IO.File.ReadAllBytes(vcFilePath);
                    return File(filepdf, contentType, referenceDocument);
                }
                else
                {
                    return NotFound();
                }
            }
            if (orderDocument != "null")
            {
                var vcFolder = myAppSettingsOptions.VC;
                var vcOrderFolder = myAppSettingsOptions.VCOrder;
                var vcFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, survivorCode, vcFolder, vcOrderFolder, orderDocument);
                if (System.IO.File.Exists(vcFilePath))
                {
                    var filepdf = System.IO.File.ReadAllBytes(vcFilePath);
                    return File(filepdf, contentType, orderDocument);
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