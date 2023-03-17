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
    public class SectionController : ControllerBase
    {
        private readonly ISection actSection;
        private readonly ILogger<SectionController> logger;
        private readonly IMapper mapper;

        public SectionController(ISection actSection, ILogger<SectionController> logger, IMapper mapper)
        {
            this.actSection = actSection;
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
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = actSection.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(SectionDTOAdd actSectionDTOAdd)
        {
            string userName = User.Identity.Name;
            SectionDTOAddDB actSectionDTOAddDB = mapper.Map<SectionDTOAddDB>(actSectionDTOAdd);
            actSectionDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            actSectionDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{actSectionDTOAddDB}");
            var result = actSection.Add(actSectionDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(SectionDTOEdit actSectionDTOEdit)
        {
            string userName = User.Identity.Name;
            SectionDTOEditDB actSectionDTOEditDB = mapper.Map<SectionDTOEditDB>(actSectionDTOEdit);
            actSectionDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            actSectionDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{actSectionDTOEditDB}");
            var result = actSection.Edit(actSectionDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{actSectionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int actSectionCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},ActSectionCode:{actSectionCode}");
            var result = actSection.Delete(actSectionCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{actSectionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int actSectionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},ActSectionCode:{actSectionCode}");
            var result = actSection.Detail(actSectionCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{actSectionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int actSectionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},ActSectionCode:{actSectionCode}");
            var result = actSection.ChangeLog_GetById(actSectionCode, userName);
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
            var result = actSection.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}