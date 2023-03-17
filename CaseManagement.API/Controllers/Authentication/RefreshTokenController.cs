using CaseManagement.Models.AuthData;
using CaseManagement.Repository.AuthData.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;

namespace CaseManagement.API.Controllers.Authentication
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RefreshTokenController : ControllerBase
    {
        private readonly ILogger<RefreshTokenController> logger;
        private readonly TokenGenerator tokenGenerator;
        private readonly IAppUser appUser;
        public RefreshTokenController(ILogger<RefreshTokenController> logger, TokenGenerator tokenGenerator, IAppUser appUser)
        {
            this.logger = logger;
            this.tokenGenerator = tokenGenerator;
            this.appUser = appUser;
        }
        [HttpPost]
        public IActionResult Refresh()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userName = identity.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();
            var userRole = identity.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault();

            logger.LogInformation($"Refresh Token for user {userName} having user role is {userRole}");
            string userAgent = Utility.GetUserAgent(Request);
            string iPAddress = Utility.GetIPAddress(Request);
            var userLoginHistoryDetail = appUser.UserHistoryInsert(userName.Value, userAgent, iPAddress, true);
            var result = tokenGenerator.GenerateToken(userName.Value, userRole.Value, userLoginHistoryDetail.LoginHistoryId.ToString(), userLoginHistoryDetail.IsConsentRequired);
            logger.LogInformation($"Refresh Token result for user {userName} having user role is {userRole} is {result}");
            return Ok(result);
        }
    }
}
