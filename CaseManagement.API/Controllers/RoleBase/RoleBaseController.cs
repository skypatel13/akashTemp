using AutoMapper;
using CaseManagement.API.Controllers.Authentication;
using CaseManagement.Models.Admin;
using CaseManagement.Models.RoleBase;
using CaseManagement.Repository.AuthData.Interfaces;
using CaseManagement.Repository.Interfaces;
using CaseManagement.Repository.RoleBase.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static CaseManagement.UtilityLibrary.Utility;
namespace CaseManagement.API.Controllers.RoleBase
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RoleBaseController : ControllerBase
    {
        private readonly IRoleBase roleBase;
        private readonly ILogger<AuthenticateController> logger;
        private readonly IMapper mapper;
        public RoleBaseController(ILogger<AuthenticateController> logger, IRoleBase roleBase, IMapper mapper)
        {
            this.logger = logger;
            this.roleBase = roleBase;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult RoleBasedMenu_GetByUserName()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = roleBase.RoleBasedMenu_GetByUserName(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{roleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Features_GetByRole(string roleId)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},Role ID:{roleId},IP:{iPAddress}");
            var result = roleBase.Features_GetByRole_Admin(roleId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Features_Insert_ByRole_Admin(RoleBaseFeaturesDTOInsert roleBaseFeaturesDTOInsert)
        {
            string userName = User.Identity.Name;
            RoleBaseFeaturesDTOInsertDB roleBaseFeaturesDTOInsertDB = mapper.Map<RoleBaseFeaturesDTOInsertDB>(roleBaseFeaturesDTOInsert);
            string featureDataXml = GetXMLString(roleBaseFeaturesDTOInsert.FeaturesData);
            string featureActionDataXml = GetXMLString(roleBaseFeaturesDTOInsert.FeaturesActionData);
            roleBaseFeaturesDTOInsertDB.CreatedByIpAddress = GetIPAddress(Request);
            roleBaseFeaturesDTOInsertDB.CreatedBy = userName;
            roleBaseFeaturesDTOInsertDB.FeaturesData = featureDataXml;
            roleBaseFeaturesDTOInsertDB.FeaturesActionData = featureActionDataXml;
            logger.LogInformation($"| Request Argument:{roleBaseFeaturesDTOInsertDB}");
            var result = roleBase.Features_Insert_ByRole_Admin(roleBaseFeaturesDTOInsertDB);
            logger.LogInformation($"| Result: {result}");
            return Ok(result);
        }
    }
}
