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
    public class StateController : ControllerBase
    {
        private readonly IState state;
        private readonly ILogger<StateController> logger;
        private readonly IMapper mapper;

        public StateController(IState state, ILogger<StateController> logger, IMapper mapper)
        {
            this.state = state;
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
            logger.LogInformation($"Request State List User: {userName},IP:{iPAddress}");
            var result = state.List(userName);
            logger.LogInformation($"Result State List: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request State Deleted List User: {userName},IP:{iPAddress}, Argument:userName:{userName}");
            var result = state.Deleted_List(userName);
            logger.LogInformation($"Result State Deleted List : {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(StateDTOAdd stateDTOAdd)
        {
            string userName = User.Identity.Name;
            StateDTOAddDB stateDTOAddDB = mapper.Map<StateDTOAddDB>(stateDTOAdd);
            stateDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            stateDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"Request State Add Argument:{stateDTOAddDB}");
            var result = state.Add(stateDTOAddDB);
            logger.LogInformation($"Result State Add: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{stateCode:int}")]
        public IActionResult Delete(int stateCode)
        {
            string userName = User.Identity.Name;
            string ip = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request State Delete:Argument:{userName},IP:{ip},StateCode:{stateCode}");
            var result = state.Delete(stateCode, userName, Utility.GetIPAddress(Request));
            logger.LogInformation($"Result:State Delete:{result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{stateCode:int}")]
        public IActionResult Detail(int stateCode)
        {
            string userName = User.Identity.Name;
            string ip = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request State Detail:Argument:{userName},IP:{ip},StateCode:{stateCode}");
            var result = state.Detail(stateCode, userName);
            logger.LogInformation($"Result:State Detail:{result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(StateDTOEdit stateDTOEdit)
        {
            string userName = User.Identity.Name;
            StateDTOEditDB stateDTOEditDB = mapper.Map<StateDTOEditDB>(stateDTOEdit);
            stateDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            stateDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"Request State Edit Argument:{stateDTOEditDB}");
            var result = state.Edit(stateDTOEditDB);
            logger.LogInformation($"Result State Edit {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{stateCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int stateCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|User: {userName},IP:{iPAddress}, Argument:stateCode:{stateCode}");
            var result = state.ChangeLog_GetById(stateCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}