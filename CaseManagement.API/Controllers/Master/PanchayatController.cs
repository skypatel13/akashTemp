using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PanchayatController : ControllerBase
    {
        private readonly IPanchayat panchayat;
        private readonly ILogger<PanchayatController> logger;
        private readonly IMapper mapper;

        public PanchayatController(IPanchayat panchayat, ILogger<PanchayatController> logger, IMapper mapper)
        {
            this.panchayat = panchayat;
            this.logger = logger;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = panchayat.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(PanchayatDTOAdd panchayatDTOAdd)
        {
            string userName = User.Identity.Name;
            PanchayatDTOAddDB panchayatDTOAddDB = mapper.Map<PanchayatDTOAddDB>(panchayatDTOAdd);
            panchayatDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            panchayatDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{panchayatDTOAddDB}");
            var result = panchayat.Add(panchayatDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(PanchayatDTOEdit panchayatDTOEdit)
        {
            string userName = User.Identity.Name;
            PanchayatDTOEditDB panchayatDTOEditDB = mapper.Map<PanchayatDTOEditDB>(panchayatDTOEdit);
            panchayatDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            panchayatDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{panchayatDTOEditDB}");
            var result = panchayat.Edit(panchayatDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{panchayatCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int panchayatCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},PanchayatCode:{panchayatCode}");
            var result = panchayat.Delete(panchayatCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{panchayatCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int panchayatCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},PanchayatCode:{panchayatCode}");
            var result = panchayat.Detail(panchayatCode, userName);
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
            var result = panchayat.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{panchayatCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int panchayatCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|User: {userName},IP:{iPAddress}, Argument:panchayatCode:{panchayatCode}");
            var result = panchayat.ChangeLog_GetById(panchayatCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}