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
    public class PartnerController : ControllerBase
    {
        private readonly IPartner partner;
        private readonly ILogger<PartnerController> logger;
        private readonly IMapper mapper;

        public PartnerController(IPartner partner, ILogger<PartnerController> logger, IMapper mapper)
        {
            this.partner = partner;
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
            logger.LogInformation($"Request Partner List User: {userName},IP:{iPAddress}");
            var result = partner.List(userName);
            logger.LogInformation($"Result Partner List: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request Partner Deleted List User: {userName},IP:{iPAddress}");
            var result = partner.Deleted_List(userName);
            logger.LogInformation($"Result Partner Deleted List: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(PartnerDTOAdd partnerDTOAdd)
        {
            string userName = User.Identity.Name;
            PartnerDTOAddDB partnerDTOAddDB = mapper.Map<PartnerDTOAddDB>(partnerDTOAdd);
            partnerDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            partnerDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"Request Partner Add:{partnerDTOAddDB}");
            var result = partner.Add(partnerDTOAddDB);
            logger.LogInformation($"Result Partner Add:{result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(PartnerDTOEdit partnerDTOEdit)
        {
            string userName = User.Identity.Name;
            PartnerDTOEditDB partnerDTOEditDB = mapper.Map<PartnerDTOEditDB>(partnerDTOEdit);
            partnerDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            partnerDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"Request Partner Edit:{partnerDTOEditDB}");
            var result = partner.Edit(partnerDTOEditDB);
            logger.LogInformation($"Result Partner Edit:{result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{partnerCode:int}")]
        public IActionResult Delete(int partnerCode)
        {
            string userName = User.Identity.Name;
            string ip = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request:Partner Delete:{userName},PartnerCode:{partnerCode},IP:{ip}");
            var result = partner.Delete(partnerCode, userName, Utility.GetIPAddress(Request));
            logger.LogInformation($"Result:Partner Delete:{result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{partnerCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int partnerCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request Partner Detail User: {userName},IP:{iPAddress}, Argument:PartnerCode:{partnerCode}");
            var result = partner.Detail(userName, partnerCode);
            logger.LogInformation($"Result Partner Detail : {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{partnerCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int partnerCode)
        {
            //string userName = User.Identity.Name;
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request Partner ChangeLog_GetById User: {userName},IP:{iPAddress},PartnerCode:{partnerCode}");
            var result = partner.ChangeLog_GetById(userName, partnerCode);
            logger.LogInformation($"Result Partner ChangeLog_GetById {result}");
            return Ok(result);
        }
    }
}