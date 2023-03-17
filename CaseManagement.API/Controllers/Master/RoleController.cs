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
    public class RoleController : ControllerBase
    {
        private readonly IRole role;
        private readonly ILogger<RoleController> logger;
        private readonly IMapper mapper;

        public RoleController(IRole role, ILogger<RoleController> logger, IMapper mapper)
        {
            this.role = role;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(RoleDTOAdd roleDTOAdd)
        {
            string userName = User.Identity.Name;
            RoleDTOAddDB roleDTOAddDB = mapper.Map<RoleDTOAddDB>(roleDTOAdd);
            roleDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            roleDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{roleDTOAddDB}");
            var result = role.Add(roleDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(RoleDTOEdit roleDTOEdit )
        {
            string userName = User.Identity.Name;
            RoleDTOEditDB roleDTOEditDB = mapper.Map<RoleDTOEditDB>(roleDTOEdit);
            roleDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            roleDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{roleDTOEditDB}");
            var result = role.Edit(roleDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = role.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{roleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(string roleId)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},RoleId:{roleId}");
            var result = role.Delete(roleId, userName, iPAddress);
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
            var result = role.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{roleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(string roleId)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},RoleId:{roleId}");
            var result = role.ChangeLog_GetById(roleId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{roleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(string roleId)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},RoleId:{roleId}");
            var result = role.Detail(roleId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}