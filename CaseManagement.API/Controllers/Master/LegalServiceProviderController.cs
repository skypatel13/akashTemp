using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CaseManagement.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LegalServiceProviderController : ControllerBase
    {
        private readonly ILegalServiceProvider legalServiceProvider;
        private readonly ILogger<LegalServiceProviderController> logger;
        private readonly IMapper mapper;

        public LegalServiceProviderController(ILegalServiceProvider legalServiceProvider, ILogger<LegalServiceProviderController> logger, IMapper mapper)
        {
            this.legalServiceProvider = legalServiceProvider;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = legalServiceProvider.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(LegalServiceProviderDTOAdd legalServiceProviderDTOAdd)
        {
            string userName = User.Identity.Name;
            LegalServiceProviderDTOAddDB legalServiceProviderDTOAddDB = mapper.Map<LegalServiceProviderDTOAddDB>(legalServiceProviderDTOAdd);
            legalServiceProviderDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            legalServiceProviderDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{legalServiceProviderDTOAddDB}");
            var result = legalServiceProvider.Add(legalServiceProviderDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(LegalServiceProviderDTOEdit legalServiceProviderDTOEdit)
        {
            string userName = User.Identity.Name;
            LegalServiceProviderDTOEditDB legalServiceProviderDTOEditDB = mapper.Map<LegalServiceProviderDTOEditDB>(legalServiceProviderDTOEdit);
            legalServiceProviderDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            legalServiceProviderDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{legalServiceProviderDTOEditDB}");
            var result = legalServiceProvider.Edit(legalServiceProviderDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{legalServiceProviderCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int legalServiceProviderCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},LegalServiceProviderCode:{legalServiceProviderCode}");
            var result = legalServiceProvider.Delete(legalServiceProviderCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{legalServiceProviderCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int legalServiceProviderCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},LegalServiceProviderCode:{legalServiceProviderCode}");
            var result = legalServiceProvider.Detail(legalServiceProviderCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{legalServiceProviderCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int legalServiceProviderCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},LegalServiceProviderCode:{legalServiceProviderCode}");
            var result = legalServiceProvider.ChangeLog_GetById(legalServiceProviderCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = legalServiceProvider.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}