using CaseManagement.Models.AuthData;
using CaseManagement.Repository.AuthData.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CaseManagement.API.Controllers.Authentication
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticate authenticate;
        private readonly ILogger<AuthenticateController> logger;

        public AuthenticateController(ILogger<AuthenticateController> logger, IAuthenticate authenticate)
        {
            this.logger = logger;
            this.authenticate = authenticate;
        }

        /// <summary>
        /// To authenticate user. Authenticated user can access token
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginModel login)
        {
            logger.LogInformation($"Login requested: {login.UserName}");
            string iPAddress = Utility.GetIPAddress(Request);
            string userAgent = Utility.GetUserAgent(Request);
            var result = await authenticate.AuthenticateUser(login, userAgent, iPAddress);
            if (result == null)
            {
                logger.LogInformation($"Invalid UserName or Password for User {login.UserName}");
                return Unauthorized();
            }
            else
            {
                logger.LogInformation($"Token for login {login.UserName} is generated {result.ToString()}");
                return Ok(result);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{loginHistoryId}")]
        public IActionResult SignOut(Guid loginHistoryId)
        {
            var userName = this.User.Identity.Name;
            logger.LogInformation($"Logout requested: {userName}");
            var result = authenticate.SignOut(userName, loginHistoryId);
            if (result == null)
            {
                return Unauthorized();
            }
            logger.LogInformation($"Logout {result.ToString()}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetMemberConsent()
        {
            var userName = this.User.Identity.Name;
            logger.LogInformation($"|Request User:{userName}");
            var result = authenticate.memberConsent(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateConsent()
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress}");
            var result = authenticate.UpdateConsent(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}