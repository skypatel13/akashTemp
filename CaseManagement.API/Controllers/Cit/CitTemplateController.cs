using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static CaseManagement.UtilityLibrary.Utility;
namespace CaseManagement.API.Controllers.Cit
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CitTemplateController : ControllerBase
    {
        private readonly ICitTemplate version;
        private readonly ILogger<CitTemplateController> logger;
        private readonly IMapper mapper;
        public CitTemplateController(ICitTemplate version, ILogger<CitTemplateController> logger, IMapper mapper)
        {
            this.version = version;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = version.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(CitTemplateDTOAdd versionDTOAdd)
        {
            string userName = User.Identity.Name;
            CitTemplateDTOAddDB versionDTOAddDB = mapper.Map<CitTemplateDTOAddDB>(versionDTOAdd);
            versionDTOAddDB.EffectiveFrom = versionDTOAddDB.EffectiveFrom.ToLocalTime();
            versionDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            versionDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{versionDTOAddDB}");
            var result = version.Add(versionDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(CitTemplateDTOEdit versionDTOEdit)
        {
            string userName = User.Identity.Name;
            CitTemplateDTOEditDB versionDTOEditDB = mapper.Map<CitTemplateDTOEditDB>(versionDTOEdit);
            versionDTOEditDB.EffectiveFrom = versionDTOEditDB.EffectiveFrom.ToLocalTime();
            versionDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            versionDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{versionDTOEditDB}");
            var result = version.Edit(versionDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{versionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Obsolete(int versionCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},VersionCode:{versionCode}");
            var result = version.Obsolete(versionCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{versionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int versionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},VersionCode:{versionCode}");
            var result = version.Detail(versionCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{versionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int versionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},VersionCode:{versionCode}");
            var result = version.ChangeLog_GetById(versionCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ObsoleteList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = version.ObsoleteList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

    }
}
