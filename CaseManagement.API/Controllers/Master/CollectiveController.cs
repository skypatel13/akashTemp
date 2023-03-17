using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaseManagement.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CollectiveController : ControllerBase
    {
        private readonly ICollective collective;
        private readonly ILogger<OrganizationController> logger;
        private readonly IMapper mapper;

        public CollectiveController(ICollective collective, ILogger<OrganizationController> logger, IMapper mapper)
        {
            this.collective = collective;
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
            logger.LogInformation($"Request Collective List User: {userName},IP:{iPAddress}");
            var result = collective.List(userName);
            logger.LogInformation($"Result Collective List {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(CollectiveDTOAdd collectiveDTOAdd)
        {
            string userName = User.Identity.Name;
            CollectiveDTOAddDB collectiveDTOAddDB = mapper.Map<CollectiveDTOAddDB>(collectiveDTOAdd);
            collectiveDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            collectiveDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"Request Collective Add Argument:{collectiveDTOAddDB}");
            var result = collective.Add(collectiveDTOAddDB);
            logger.LogInformation($"Result Collective Add {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(CollectiveDTOEdit collectiveDTOEdit)
        {
            string userName = User.Identity.Name;
            CollectiveDTOEditDB collectiveDTOEditDB = mapper.Map<CollectiveDTOEditDB>(collectiveDTOEdit);
            collectiveDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            collectiveDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"Request Collective Edit Argument:{collectiveDTOEditDB}");
            var result = collective.Edit(collectiveDTOEditDB);
            logger.LogInformation($"Result Collective Edit {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{collectiveCode:int}")]
        public IActionResult Delete(int collectiveCode)
        {
            string userName = User.Identity.Name;
            string ip = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request Collective Delete User:{userName},CollectiveCode:{collectiveCode},IP:{ip}");
            var result = collective.Delete(collectiveCode, userName, Utility.GetIPAddress(Request));
            logger.LogInformation($"Result Collective Delete {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request Collective DeletedList User: {userName},IP:{iPAddress}");
            var result = collective.DeletedList(userName);
            logger.LogInformation($"Result Collective DeletedList {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{collectiveCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int collectiveCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request Collective Detail User: {userName},IP:{iPAddress}, Argument:CollectiveCode:{collectiveCode}");
            var result = collective.Detail(collectiveCode, userName);
            logger.LogInformation($"Result Collective Detail: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{collectiveCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int collectiveCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request:Collective ChangeLog_GetById User: {userName},IP:{iPAddress}, Argument:collectiveCode:{collectiveCode}");
            var result = collective.ChangeLog_GetById(collectiveCode, userName);
            logger.LogInformation($"Result:Collective ChangeLog_GetById {result}");
            return Ok(result);
        }
    }
}