using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Transaction.Survivor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SurvivorTraffickerController : ControllerBase
    {
        private readonly ISurvivorTrafficker survivorTrafficker;
        private readonly ILogger<SurvivorTraffickerController> logger;
        private readonly IMapper mapper;

        public SurvivorTraffickerController(ISurvivorTrafficker survivorTrafficker, ILogger<SurvivorTraffickerController> logger, IMapper mapper)
        {
            this.survivorTrafficker = survivorTrafficker;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{survivorCode:int?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List(int? survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = survivorTrafficker.List(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(SurvivorTraffickerDTOAdd survivorTraffickerDTOAdd)
        {
            string userName = User.Identity.Name;
            SurvivorTraffickerDTOAddDB survivorTraffickerDTOAddDB = mapper.Map<SurvivorTraffickerDTOAddDB>(survivorTraffickerDTOAdd);
            string dataXml = GetXMLString(survivorTraffickerDTOAdd.SurvivorTraffickerMappingDTOList);
            survivorTraffickerDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            survivorTraffickerDTOAddDB.CreatedBy = userName;
            survivorTraffickerDTOAddDB.DataXML = dataXml;
            logger.LogInformation($"|Request Argument:{survivorTraffickerDTOAddDB}");
            var result = survivorTrafficker.Add(survivorTraffickerDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult AddRalation(SurvivorTraffickerRelationDTOAdd survivorTraffickerRelationDTOAdd)
        {
            string userName = User.Identity.Name;
            SurvivorTraffickerRelationDTOAddDB survivorTraffickerRelationDTOAddDB = mapper.Map<SurvivorTraffickerRelationDTOAddDB>(survivorTraffickerRelationDTOAdd);
            survivorTraffickerRelationDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            survivorTraffickerRelationDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{survivorTraffickerRelationDTOAddDB}");
            var result = survivorTrafficker.AddRelation(survivorTraffickerRelationDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{traffickerRelationCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteRalation(int traffickerRelationCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|request User: {userName},IP:{iPAddress},Trafficker Relation Code:{traffickerRelationCode}");
            var result = survivorTrafficker.DeleteRelation(traffickerRelationCode, userName, iPAddress);
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
            var result = survivorTrafficker.ChangeLog_GetById(survivorCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}