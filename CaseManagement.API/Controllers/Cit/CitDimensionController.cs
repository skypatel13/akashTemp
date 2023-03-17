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
    public class CitDimensionController : ControllerBase
    {
        private readonly ICitDimension versionDimension;
        private readonly ILogger<CitDimensionController> logger;
        private readonly IMapper mapper;

        public CitDimensionController(ICitDimension versionDimension, ILogger<CitDimensionController> logger, IMapper mapper)
        {
            this.versionDimension = versionDimension;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{versionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List(int versionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},VersionCode:{versionCode}");
            var result = versionDimension.List(userName, versionCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(CitDimensionDTOAdd versionDimensionDTOAdd)
        {
            string userName = User.Identity.Name;
            CitDimensionDTOAddDB versionDimensionDTOAddDB = mapper.Map<CitDimensionDTOAddDB>(versionDimensionDTOAdd);
            versionDimensionDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            versionDimensionDTOAddDB.CreatedBy = userName;
            versionDimensionDTOAddDB.DimensionData = GetXMLString(versionDimensionDTOAdd.CitDimensionMappingDTOList);
            logger.LogInformation($"|Request Argument:{versionDimensionDTOAddDB}");
            var result = versionDimension.Add(versionDimensionDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{versionDimensionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int versionDimensionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},VersionDimensionCode:{versionDimensionCode}");
            var result = versionDimension.Detail(versionDimensionCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{versionDimensionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int versionDimensionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},VersionDimensionCode:{versionDimensionCode}");
            var result = versionDimension.ChangeLog_GetById(versionDimensionCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{versionDimensionCode:int?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult QuestionList(int versionDimensionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},VersionDimensionCode:{versionDimensionCode}");
            var result = versionDimension.QuestionList(userName, versionDimensionCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult QuestionAdd(CitDimensionQuestionDTOAdd versionDimensionQuestionDTOAdd)
        {
            string userName = User.Identity.Name;
            CitDimensionQuestionDTOAddDB versionDimensionQuestionDTOAddDB = mapper.Map<CitDimensionQuestionDTOAddDB>(versionDimensionQuestionDTOAdd);
            versionDimensionQuestionDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            versionDimensionQuestionDTOAddDB.CreatedBy = userName;
            versionDimensionQuestionDTOAddDB.QuestionData = GetXMLString(versionDimensionQuestionDTOAdd.CitDimensionQuestionMappingDTOList);
            logger.LogInformation($"|Request Argument:{versionDimensionQuestionDTOAddDB}");
            var result = versionDimension.QuestionAdd(versionDimensionQuestionDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{versionDimensionQuestionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult QuestionChangeLog_GetById(int versionDimensionQuestionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},VersionDimensionQuestionCode:{versionDimensionQuestionCode}");
            var result = versionDimension.QuestionChangeLog_GetById(userName,versionDimensionQuestionCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}