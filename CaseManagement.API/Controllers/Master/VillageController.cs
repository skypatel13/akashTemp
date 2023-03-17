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

    public class VillageController : ControllerBase
    {
        private readonly IVillage village;
        private readonly ILogger<VillageController> logger;
        private readonly IMapper mapper;

        public VillageController(IVillage village, ILogger<VillageController> logger, IMapper mapper)
        {
            this.village = village;
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
            var result = village.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(VillageDTOAdd villageDTOAdd)
        {
            string userName = User.Identity.Name;
            VillageDTOAddDB villageDTOAddDB = mapper.Map<VillageDTOAddDB>(villageDTOAdd);
            villageDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            villageDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{villageDTOAddDB}");
            var result = village.Add(villageDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(VillageDTOEdit villageDTOEdit)
        {
            string userName = User.Identity.Name;
            VillageDTOEditDB villageDTOEditDB = mapper.Map<VillageDTOEditDB>(villageDTOEdit);
            villageDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            villageDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{villageDTOEditDB}");
            var result = village.Edit(villageDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{villageCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int villageCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},VillageCode:{villageCode}");
            var result = village.Delete(villageCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{villageCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int villageCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},VillageCode:{villageCode}");
            var result = village.Detail(villageCode, userName);
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
            var result = village.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{villageCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int villageCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|User: {userName},IP:{iPAddress}, Argument:villageCode:{villageCode}");
            var result = village.ChangeLog_GetById(villageCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}
