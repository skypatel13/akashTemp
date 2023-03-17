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
    public class ShelterController : ControllerBase
    {
        private readonly IShelterHome shelterHome;
        private readonly ILogger<ShelterController> logger;
        private readonly IMapper mapper;

        public ShelterController(IShelterHome shelter, ILogger<ShelterController> logger, IMapper mapper)
        {
            this.shelterHome = shelter;
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
            var result = shelterHome.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(ShelterHomeDTOAdd shelterHomeDTOAdd)
        {
            string userName = User.Identity.Name;
            ShelterHomeDTOAddDB shelterHomeDTOAddDB = mapper.Map<ShelterHomeDTOAddDB>(shelterHomeDTOAdd);
            shelterHomeDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            shelterHomeDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{shelterHomeDTOAddDB}");
            var result = shelterHome.Add(shelterHomeDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(ShelterHomeDTOEdit shelterHomeDTOEdit)
        {
            string userName = User.Identity.Name;
            ShelterHomeDTOEditDB shelteromeDTOEditDB = mapper.Map<ShelterHomeDTOEditDB>(shelterHomeDTOEdit);
            shelteromeDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            shelteromeDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{shelteromeDTOEditDB}");
            var result = shelterHome.Edit(shelteromeDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{shelterHomeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int shelterHomeCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},ShelterHomeCode:{shelterHomeCode}");
            var result = shelterHome.Delete(shelterHomeCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{shelterHomeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int shelterHomeCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},ShelterHomeCode:{shelterHomeCode}");
            var result = shelterHome.Detail(shelterHomeCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{shelterHomeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int shelterHomeCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},ShelterHomeCode:{shelterHomeCode}");
            var result = shelterHome.ChangeLog_GetById(shelterHomeCode, userName);
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
            var result = shelterHome.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ContactList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = shelterHome.ContactList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{shelterHomeContactCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ContactDetail(int shelterHomeContactCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},ShelterHomeContactCode:{shelterHomeContactCode}");
            var result = shelterHome.ContactDetail(shelterHomeContactCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ContactAdd(ShelterHomeContactDTOAdd shelterHomeContactDTOAdd)
        {
            string userName = User.Identity.Name;
            ShelterHomeContactDTOAddDB shelterHomeContactDTOAddDB = mapper.Map<ShelterHomeContactDTOAddDB>(shelterHomeContactDTOAdd);
            shelterHomeContactDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            shelterHomeContactDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{shelterHomeContactDTOAddDB}");
            var result = shelterHome.ContactAdd(shelterHomeContactDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ContactEdit(ShelterHomeContactDTOEdit shelterHomeContactDTOEdit)
        {
            string userName = User.Identity.Name;
            ShelterHomeContactDTOEditDB shelterHomeContactDTOEditDB = mapper.Map<ShelterHomeContactDTOEditDB>(shelterHomeContactDTOEdit);
            shelterHomeContactDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            shelterHomeContactDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{shelterHomeContactDTOEditDB}");
            var result = shelterHome.ContactEdit(shelterHomeContactDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{shelterHomeContactCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ContactDelete(int shelterHomeContactCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},ShelterHomeContactCode:{shelterHomeContactCode}");
            var result = shelterHome.ContactDelete(shelterHomeContactCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ContactDeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = shelterHome.ContactDeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{shelterHomeContactCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ContactChangeLog_GetById(int shelterHomeContactCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},ShelterHomeContactCode:{shelterHomeContactCode}");
            var result = shelterHome.ContactChangeLog_GetById(shelterHomeContactCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}