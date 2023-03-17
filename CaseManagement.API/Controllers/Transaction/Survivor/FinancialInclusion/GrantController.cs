using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;

namespace CaseManagement.API.Controllers.Transaction.Survivor.FinancialInclusion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GrantController : ControllerBase
    {
        private readonly ISurvivorGrant survivorGrant;
        private readonly ILogger<GrantController> logger;
        private readonly IMapper mapper;
        private readonly MyAppSettingsOptions myAppSettingsOptions;
        public GrantController(ISurvivorGrant survivorGrant, ILogger<GrantController> logger, IMapper mapper, IOptions<MyAppSettingsOptions> myAppSettingsOptions)
        {
            this.survivorGrant = survivorGrant;
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
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:SurvivorCode:{survivorCode} User:{userName},IP:{iPAddress}");
            var result = survivorGrant.List(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add([FromForm] SurvivorGrantDTOAdd survivorGrantDTOAdd)
        {
            string userName = User.Identity.Name;
            SurvivorGrantDTOAddDB survivorGrantDTOAddDB = mapper.Map<SurvivorGrantDTOAddDB>(survivorGrantDTOAdd);
            survivorGrantDTOAddDB.ReferenceDocument = (survivorGrantDTOAdd.ReferenceDocument?.FileName);
            survivorGrantDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            survivorGrantDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{survivorGrantDTOAddDB}");
            var result = survivorGrant.Add(survivorGrantDTOAddDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (survivorGrantDTOAdd.ReferenceDocument != null)
                {
                    var loanFolder = myAppSettingsOptions.Loan;
                    var loanFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.SurvivorGrantDTODetail.SurvivorCode.ToString(), loanFolder, result.SurvivorGrantDTODetail.ReferenceDocumentStoredAs);
                    using FileStream stream = System.IO.File.Create(loanFilePath);
                    survivorGrantDTOAdd.ReferenceDocument.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit([FromForm] SurvivorGrantDTOEdit survivorGrantDTOEdit)
        {
            string userName = User.Identity.Name;
            SurvivorGrantDTOEditDB survivorGrantDTOEditDB = mapper.Map<SurvivorGrantDTOEditDB>(survivorGrantDTOEdit);
            survivorGrantDTOEditDB.ReferenceDocument = (survivorGrantDTOEdit.ReferenceDocument?.FileName);
            survivorGrantDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            survivorGrantDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{survivorGrantDTOEditDB}");
            var result = survivorGrant.Edit(survivorGrantDTOEditDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (survivorGrantDTOEdit.ReferenceDocument != null)
                {
                    var loanFolder = myAppSettingsOptions.Loan;
                    var loanFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.SurvivorGrantDTODetail.SurvivorCode.ToString(), loanFolder, result.SurvivorGrantDTODetail.ReferenceDocumentStoredAs);
                    using FileStream stream = System.IO.File.Create(loanFilePath);
                    survivorGrantDTOEdit.ReferenceDocument.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult OrderEdit([FromForm] SurvivorGrantOrderDTOEdit survivorGrantOrderDTOEdit)
        {
            string userName = User.Identity.Name;
            SurvivorGrantOrderEditDB survivorGrantOrderEditDB = mapper.Map<SurvivorGrantOrderEditDB>(survivorGrantOrderDTOEdit);
            survivorGrantOrderEditDB.OrderDocument = (survivorGrantOrderDTOEdit.OrderDocument?.FileName);
            survivorGrantOrderEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            survivorGrantOrderEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{survivorGrantOrderEditDB}");
            var result = survivorGrant.orderEdit(survivorGrantOrderEditDB);
            if (result.DataUpdateResponse.Status)
            {
                var survivorFolder = myAppSettingsOptions.Survivor;
                if (survivorGrantOrderDTOEdit.OrderDocument != null)
                {
                    var loanFolder = myAppSettingsOptions.Loan;
                    var loanFilePath = Path.Combine(myAppSettingsOptions.BasePath, survivorFolder, result.SurvivorGrantDTODetail.SurvivorCode.ToString(), loanFolder, result.SurvivorGrantDTODetail.ReferenceDocumentStoredAs);
                    using FileStream stream = System.IO.File.Create(loanFilePath);
                    survivorGrantOrderDTOEdit.OrderDocument.CopyTo(stream);
                }
            }
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{grantCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int grantCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},GrantCode:{grantCode}");
            var result = survivorGrant.Detail(grantCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{grantCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int grantCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},GrantCode:{grantCode}");
            var result = survivorGrant.Delete(grantCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{survivorCode:int}")]
        public IActionResult DeletedList(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode{survivorCode}");
            var result = survivorGrant.DeletedList(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{grantCode:int}")]
        public IActionResult ChangeLog_GetById(int grantCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},GrantCode{grantCode}");
            var result = survivorGrant.ChangeLog_GetById(grantCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}
