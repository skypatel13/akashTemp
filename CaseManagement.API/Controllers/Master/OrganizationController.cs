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
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganization organization;
        private readonly ILogger<OrganizationController> logger;
        private readonly IMapper mapper;

        public OrganizationController(IOrganization organization, ILogger<OrganizationController> logger, IMapper mapper)
        {
            this.organization = organization;
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
            logger.LogInformation($"Reuqest Organization List User: {userName},IP:{iPAddress}, Argument:userName:{userName}");
            var result = organization.List(userName);
            logger.LogInformation($"Result Organization List:{result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request Organization Deleted List User: {userName},IP:{iPAddress}, Argument:userName:{userName}");
            var result = organization.Deleted_List(userName);
            logger.LogInformation($"Result Organization Deleted List: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(OrganizationDTOAdd organizationDTOAdd)
        {
            string userName = User.Identity.Name;
            OrganizationDTOAddDB organizationDTOAddDB = mapper.Map<OrganizationDTOAddDB>(organizationDTOAdd);
            organizationDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            organizationDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"Request Organization Add Argument:{organizationDTOAddDB}");
            var result = organization.Add(organizationDTOAddDB);
            logger.LogInformation($"Result Organization Add: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{organizationId:int}")]
        public IActionResult Delete(int organizationId)
        {
            string userName = User.Identity.Name;
            string ip = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request Organization Delete:{userName},OrganizationId:{organizationId},IP:{ip}");
            var result = organization.Delete(organizationId, userName, Utility.GetIPAddress(Request));
            logger.LogInformation($"Result Organization Delete:{result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(OrganizationDTOEdit organizationDTOEdit)
        {
            string userName = User.Identity.Name;
            OrganizationDTOEditDB organizationDTOEditDB = mapper.Map<OrganizationDTOEditDB>(organizationDTOEdit);
            organizationDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            organizationDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"Request Organization Edit Argument:{organizationDTOEditDB}");
            var result = organization.Edit(organizationDTOEditDB);
            logger.LogInformation($"Result Organization Edit: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{organizationId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int organizationId)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|User: {userName},IP:{iPAddress}, Argument:organizationId:{organizationId}");
            var result = organization.Detail(organizationId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{organizationId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int organizationId)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|User: {userName},IP:{iPAddress}, Argument:organizationId:{organizationId}");
            var result = organization.ChangeLog_GetById(organizationId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}