using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaseManagement.API.Controllers.Transaction.Survivor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RescueController : ControllerBase
    {
        private readonly IRescue rescue;
        private readonly ILogger<RescueController> logger;
        private readonly IMapper mapper;

        public RescueController(IRescue rescue, ILogger<RescueController> logger, IMapper mapper)
        {
            this.rescue = rescue;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List(int? survivorCode = 0)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = rescue.List(userName,survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(RescueDTOAdd rescueDTOAdd)
        {
            string userName = User.Identity.Name;
            RescueDTOAddDB rescueDTOAddDB = mapper.Map<RescueDTOAddDB>(rescueDTOAdd);
            rescueDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            rescueDTOAddDB.CreatedBy = userName;
            rescueDTOAddDB.RescueDate = rescueDTOAdd.RescueDate.ToLocalTime();
            logger.LogInformation($"|Request Argument:{rescueDTOAddDB}");
            var result = rescue.Add(rescueDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(RescueDTOEdit rescueDTOEdit)
        {
            string userName = User.Identity.Name;
            RescueDTOEditDB rescueDTOEditDB = mapper.Map<RescueDTOEditDB>(rescueDTOEdit);
            rescueDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            rescueDTOEditDB.ModifiedBy = userName;
            rescueDTOEditDB.RescueDate = rescueDTOEdit.RescueDate.ToLocalTime();
            logger.LogInformation($"|Request Argument:{rescueDTOEditDB}");
            var result = rescue.Edit(rescueDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{rescueCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int rescueCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},RescueCode:{rescueCode}");
            var result = rescue.Delete(rescueCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{rescueCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int rescueCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},RescueCode:{rescueCode}");
            var result = rescue.Detail(rescueCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{rescueCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int rescueCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},RescueCode:{rescueCode}");
            var result = rescue.ChangeLog_GetById(rescueCode, userName);
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
            var result = rescue.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}