using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaseManagement.API.Controllers.Transaction.Survivor.FinancialInclusion
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class IncomeController : ControllerBase
    {
        private readonly ISurvivorIncome survivorIncome;
        private readonly ILogger<IncomeController> logger;
        private readonly IMapper mapper;
        public IncomeController(ISurvivorIncome survivorIncome, ILogger<IncomeController> logger, IMapper mapper)
        {
            this.survivorIncome = survivorIncome;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{survivorCode:int}")]
        public IActionResult List(int? survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:SurvivorCode:{survivorCode} User:{userName},IP:{iPAddress}");
            var result = survivorIncome.List(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(SurvivorIncomeDTOAdd survivorIncomeDTOAdd)
        {
            string userName = User.Identity.Name;
            SurvivorIncomeDTOAddDB survivorIncomeDTOAddDB = mapper.Map<SurvivorIncomeDTOAddDB>(survivorIncomeDTOAdd);
            survivorIncomeDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            survivorIncomeDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"Request Argument:{survivorIncomeDTOAddDB}");
            var result = survivorIncome.Add(survivorIncomeDTOAddDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(SurvivorIncomeDTOEdit survivorIncomeDTOEdit)
        {
            string userName = User.Identity.Name;
            SurvivorIncomeDTOEditDB survivorIncomeDTOEditDB = mapper.Map<SurvivorIncomeDTOEditDB>(survivorIncomeDTOEdit);
            survivorIncomeDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            survivorIncomeDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"Request Argument:{survivorIncomeDTOEditDB}");
            var result = survivorIncome.Edit(survivorIncomeDTOEditDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{incomeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int incomeCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request: UserName:{userName},IP:{iPAddress},IncomeCode:{incomeCode}");
            var result = survivorIncome.Detail(incomeCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{incomeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int incomeCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|request User: {userName},IP:{iPAddress},IncomeCode:{incomeCode}");
            var result = survivorIncome.Delete(incomeCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{survivorCode:int}")]
        public IActionResult DeletedList(int? survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:SurvivorCode:{survivorCode} User:{userName},IP:{iPAddress}");
            var result = survivorIncome.DeletedList(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{incomeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int incomeCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},IncomeCode:{incomeCode}");
            var result = survivorIncome.ChangeLog_GetById(incomeCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}
