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
    public class AhtuController : ControllerBase
    {
        private readonly IAhtu ahtu;
        private readonly ILogger<AhtuController> logger;
        private readonly IMapper mapper;
        public AhtuController(IAhtu ahtu, ILogger<AhtuController> logger, IMapper mapper)
        {
            this.ahtu = ahtu;
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
            var result = ahtu.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(AhtuDTOAdd ahtuDTOAdd)
        {
            string userName = User.Identity.Name;
            AhtuDTOAddDB ahtuDTOAddDB = mapper.Map<AhtuDTOAddDB>(ahtuDTOAdd);
            ahtuDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            ahtuDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{ahtuDTOAddDB}");
            var result = ahtu.Add(ahtuDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(AhtuDTOEdit ahtuDTOEdit)
        {
            string userName = User.Identity.Name;
            AhtuDTOEditDB ahtuDTOEditDB = mapper.Map<AhtuDTOEditDB>(ahtuDTOEdit);
            ahtuDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            ahtuDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{ahtuDTOEditDB}");
            var result = ahtu.Edit(ahtuDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{ahtuCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int ahtuCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},AhtuCode:{ahtuCode}");
            var result = ahtu.Delete(ahtuCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{ahtuCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int ahtuCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},AhtuCode:{ahtuCode}");
            var result = ahtu.Detail(ahtuCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{ahtuCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int ahtuCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},AhtuCode:{ahtuCode}");
            var result = ahtu.ChangeLog_GetById(ahtuCode, userName);
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
            var result = ahtu.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}
