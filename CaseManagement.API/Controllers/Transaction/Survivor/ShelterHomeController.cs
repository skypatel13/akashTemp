using AutoMapper;
using CaseManagement.API.Controllers.Transaction.Survivor.FinancialInclusion;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CaseManagement.API.Controllers.Transaction.Survivor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShelterHomeController : ControllerBase
    {
        private readonly ISurvivorShelter survivorShelter;
        private readonly ILogger<ShelterHomeController> logger;
        private readonly IMapper mapper;
        public ShelterHomeController(ISurvivorShelter survivorShelter, ILogger<ShelterHomeController> logger, IMapper mapper)
        {
            this.survivorShelter = survivorShelter;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{survivorCode:int}")]
        public IActionResult List(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:SurvivorCode:{survivorCode} User:{userName},IP:{iPAddress}");
            var result = survivorShelter.List(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(SurvivorShelterDTOAdd survivorShelterDTOAdd)
        {
            string userName = User.Identity.Name;
            SurvivorShelterDTOAddDB survivorShelterDTOAddDB = mapper.Map<SurvivorShelterDTOAddDB>(survivorShelterDTOAdd);
            survivorShelterDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            survivorShelterDTOAddDB.CreatedBy = userName;
            if (survivorShelterDTOAdd.FromDate != null)
                survivorShelterDTOAddDB.FromDate = survivorShelterDTOAdd.FromDate.Value.ToLocalTime();
            if (survivorShelterDTOAdd.ToDate != null)
                survivorShelterDTOAddDB.ToDate = survivorShelterDTOAdd.ToDate.Value.ToLocalTime();
            logger.LogInformation($"Request Argument:{survivorShelterDTOAddDB}");
            var result = survivorShelter.Add(survivorShelterDTOAddDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(SurvivorShelterDTOEdit survivorShelterDTOEdit)
        {
            string userName = User.Identity.Name;
            SurvivorShelterDTOEditDB survivorShelterDTOEditDB = mapper.Map<SurvivorShelterDTOEditDB>(survivorShelterDTOEdit);
            survivorShelterDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            survivorShelterDTOEditDB.ModifiedBy = userName;
            if (survivorShelterDTOEdit.FromDate != null)
                survivorShelterDTOEditDB.FromDate = survivorShelterDTOEdit.FromDate.Value.ToLocalTime();
            if (survivorShelterDTOEdit.ToDate != null)
                survivorShelterDTOEditDB.ToDate = survivorShelterDTOEdit.ToDate.Value.ToLocalTime();
            logger.LogInformation($"Request Argument:{survivorShelterDTOEditDB}");
            var result = survivorShelter.Edit(survivorShelterDTOEditDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{survivorShelterHomeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int survivorShelterHomeCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request: UserName:{userName},IP:{iPAddress},Survivor ShelterHome Code:{survivorShelterHomeCode}");
            var result = survivorShelter.Detail(survivorShelterHomeCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{survivorShelterHomeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int survivorShelterHomeCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|request User: {userName},IP:{iPAddress},Survivor ShelterHome Code:{survivorShelterHomeCode}");
            var result = survivorShelter.Delete(survivorShelterHomeCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{survivorCode:int}")]
        public IActionResult DeletedList(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:SurvivorCode:{survivorCode} User:{userName},IP:{iPAddress}");
            var result = survivorShelter.DeletedList(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{survivorShelterHomeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int survivorShelterHomeCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},Survivor ShelterHome Code:{survivorShelterHomeCode}");
            var result = survivorShelter.ChangeLog_GetById(survivorShelterHomeCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}
