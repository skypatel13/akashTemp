using AutoMapper;
using CaseManagement.Models.AuthData;
using CaseManagement.Repository.AuthData.Interfaces;
using CaseManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CaseManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IAppUser appUser;
        private readonly ILogger<UserProfileController> logger;
        private readonly IMapper mapper;
        public UserProfileController(IAppUser appUser, ILogger<UserProfileController> logger, IMapper mapper)
        {
            this.appUser = appUser;
            this.logger = logger;
            this.mapper = mapper;
        }
        /// <summary>
        /// To update password of logged in user
        /// </summary>
        /// <param name="updatePasswordDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> UpdatePasswordAsync(UpdatePasswordDTO updatePasswordDTO)
        {
            logger.LogInformation($"Update passowrd for {updatePasswordDTO}");
            UpdatePasswordDTODB updatePasswordDTODB = mapper.Map<UpdatePasswordDTODB>(updatePasswordDTO);
            updatePasswordDTODB.UserName = User.Identity.Name;
            var result = await appUser.UpdatePassword(updatePasswordDTODB);
            logger.LogInformation($"Result for update password for {updatePasswordDTO} is {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UserDetail()
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request:User:{userName}");
            var result = appUser.UserProfileDetail(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{mobile}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UserMobileUpdate(string mobile)
        {
            string userName = User.Identity.Name;
            logger.LogInformation($"|Request:User:{userName}");
            var result = appUser.UserDetails_Update(mobile, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}
