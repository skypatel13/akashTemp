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
    public class ShgController : ControllerBase
    {
        private readonly IShg shg;
        private readonly ILogger<ShgController> logger;
        private readonly IMapper mapper;

        public ShgController(IShg shg, ILogger<ShgController> logger, IMapper mapper)
        {
            this.shg = shg;
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
            logger.LogInformation($"Request SHG List User: {userName},IP:{iPAddress}");
            var result = shg.List(userName);
            logger.LogInformation($"Result SHG List: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(ShgDTOAdd shgDTOAdd)
        {
            string userName = User.Identity.Name;
            ShgDTOAddDB shgDTOAddDB = mapper.Map<ShgDTOAddDB>(shgDTOAdd);
            shgDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            shgDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"Request SHG Add Argument:{shgDTOAddDB}");
            var result = shg.Add(shgDTOAddDB);
            logger.LogInformation($"Result SHG Add :{result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(ShgDTOEdit shgDTOEdit)
        {
            string userName = User.Identity.Name;
            ShgDTOEditDB shgDTOEditDB = mapper.Map<ShgDTOEditDB>(shgDTOEdit);
            shgDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            shgDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"Request SHG Edit Argument:{shgDTOEditDB}");
            var result = shg.Edit(shgDTOEditDB);
            logger.LogInformation($"Result SHG Edit: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{shgCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int shgCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request SHG Detail User: {userName},IP:{iPAddress}, Argument:shgCode:{shgCode}");
            var result = shg.Detail(shgCode, userName);
            logger.LogInformation($"Result SHG Detail: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{shgCode:int}")]
        public IActionResult Delete(int shgCode)
        {
            string userName = User.Identity.Name;
            string ip = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request:SHG Delete:{userName},shgCode:{shgCode},IP:{ip}");
            var result = shg.Delete(shgCode, userName, Utility.GetIPAddress(Request));
            logger.LogInformation($"Result:SHG Delete:{result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request SHG Deleted List User: {userName},IP:{iPAddress}");
            var result = shg.DeletedList(userName);
            logger.LogInformation($"Result SHG Deleted List  {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{shgCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int shgCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request ChangeLog_GetById User: {userName},IP:{iPAddress}, Argument:shgCode:{shgCode}");
            var result = shg.ChangeLog_GetById(shgCode, userName);
            logger.LogInformation($"Result ChangeLog_GetById : {result}");
            return Ok(result);
        }
    }
}