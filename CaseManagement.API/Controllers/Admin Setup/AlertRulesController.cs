using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaseManagement.API.Controllers.Admin_Setup
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AlertRulesController : ControllerBase
    {
        private readonly IAlertRules alertRules;
        private readonly ILogger<AlertRulesController> logger;

        public AlertRulesController(IAlertRules alertRules, ILogger<AlertRulesController> logger)
        {
            this.alertRules = alertRules;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = alertRules.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{rulesId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int rulesId)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},RulesId:{rulesId}");
            var result = alertRules.Detail(rulesId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}