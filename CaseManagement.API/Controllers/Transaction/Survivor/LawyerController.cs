using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Transaction.Survivor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LawyerController : ControllerBase
    {
        private readonly ILawyer lawyer;
        private readonly ILogger<LawyerController> logger;
        private readonly IMapper mapper;

        public LawyerController(ILawyer lawyer, ILogger<LawyerController> logger, IMapper mapper)
        {
            this.lawyer = lawyer;
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
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = lawyer.List(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(LawyerDTOAdd lawyerDTOAdd)
        {
            string userName = User.Identity.Name;
            LawyerDTOAddDB lawyerDTOAddDB = mapper.Map<LawyerDTOAddDB>(lawyerDTOAdd);
            lawyerDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            lawyerDTOAddDB.CreatedBy = userName;
            if (lawyerDTOAdd.LeadingFrom != null)
            {
                lawyerDTOAddDB.LeadingFrom = lawyerDTOAddDB.LeadingFrom?.ToLocalTime();
            }
            if (lawyerDTOAdd.LeadingTo != null)
            {
                lawyerDTOAddDB.LeadingTo = lawyerDTOAddDB.LeadingTo?.ToLocalTime();
            }
            logger.LogInformation($"|Request Argument:{lawyerDTOAddDB}");
            var result = lawyer.Add(lawyerDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(LawyerDTOEdit lawyerDTOEdit)
        {
            string userName = User.Identity.Name;
            LawyerDTOEditDB lawyerDTOEditDB = mapper.Map<LawyerDTOEditDB>(lawyerDTOEdit);
            lawyerDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            lawyerDTOEditDB.ModifiedBy = userName;
            if (lawyerDTOEdit.LeadingFrom != null)
            {
                lawyerDTOEditDB.LeadingFrom = lawyerDTOEditDB.LeadingFrom?.ToLocalTime();
            }
            if (lawyerDTOEdit.LeadingTo != null)
            {
                lawyerDTOEditDB.LeadingTo = lawyerDTOEditDB.LeadingTo?.ToLocalTime();
            }
            logger.LogInformation($"|Request Argument:{lawyerDTOEditDB}");
            var result = lawyer.Edit(lawyerDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{survivorLawyerCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int survivorLawyerCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},SurvivorLawyerCode:{survivorLawyerCode}");
            var result = lawyer.Delete(survivorLawyerCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{survivorLawyerCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int survivorLawyerCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorLawyerCode:{survivorLawyerCode}");
            var result = lawyer.Detail(survivorLawyerCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{survivorLawyerCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int survivorLawyerCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorLawyerCode:{survivorLawyerCode}");
            var result = lawyer.ChangeLog_GetById(survivorLawyerCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = lawyer.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult LawyerListBySurvivorGetByCode(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode:{survivorCode}");
            var result = lawyer.LawyerListBySurvivorGetByCode(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

    }
}