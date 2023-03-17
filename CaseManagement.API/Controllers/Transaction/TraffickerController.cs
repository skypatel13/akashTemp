using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Transaction
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TraffickerController : ControllerBase
    {
        private readonly ITrafficker trafficker;
        private readonly ILogger<TraffickerController> logger;
        private readonly IMapper mapper;

        public TraffickerController(ITrafficker trafficker, ILogger<TraffickerController> logger, IMapper mapper)
        {
            this.trafficker = trafficker;
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
            var result = trafficker.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(TraffickerDTOAdd traffickerDTOAdd)
        {
            string userName = User.Identity.Name;
            TraffickerDTOAddDB traffickerDTOAddDB = mapper.Map<TraffickerDTOAddDB>(traffickerDTOAdd);
            traffickerDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            traffickerDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{traffickerDTOAddDB}");
            var result = trafficker.Add(traffickerDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(TraffickerDTOEdit traffickerDTOEdit)
        {
            string userName = User.Identity.Name;
            TraffickerDTOEditDB traffickerDTOEditDB = mapper.Map<TraffickerDTOEditDB>(traffickerDTOEdit);
            traffickerDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            traffickerDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{traffickerDTOEditDB}");
            var result = trafficker.Edit(traffickerDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{traffickerCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int traffickerCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},TraffickerCode:{traffickerCode}");
            var result = trafficker.Delete(traffickerCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{traffickerCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int traffickerCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},TraffickerCode:{traffickerCode}");
            var result = trafficker.Detail(traffickerCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{traffickerCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int traffickerCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},TraffickerCode:{traffickerCode}");
            var result = trafficker.ChangeLog_GetById(traffickerCode, userName);
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
            var result = trafficker.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{traffickerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult FirTraffickerList_ById(string traffickerId)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},TraffickerId:{traffickerId}");
            var result = trafficker.firTraffickerResponse(traffickerId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{traffickerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SurvivorListByTraffickerId(string traffickerId)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},TraffickerId:{traffickerId}");
            var result = trafficker.survivorTraffickerResponse(traffickerId, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult traffickerstatus(TraffickerStatusDTOAdd traffickerStatusDTOAdd)
        {
            string userName = User.Identity.Name;
            TraffickerStatusDTOAddDB traffickerStatusDTOAddDB = mapper.Map<TraffickerStatusDTOAddDB>(traffickerStatusDTOAdd);
            traffickerStatusDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            traffickerStatusDTOAddDB.CreatedBy = userName;
            traffickerStatusDTOAddDB.StatusDate = traffickerStatusDTOAdd.StatusDate?.ToLocalTime();
            logger.LogInformation($"|Request Argument:{traffickerStatusDTOAddDB}");
            var result = trafficker.traffickerStatusResponse(traffickerStatusDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{traffickerStatusLogCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteStatus(int traffickerStatusLogCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},Trafficker Status LogCode:{traffickerStatusLogCode}");
            var result = trafficker.traffickerStatusDelete(traffickerStatusLogCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}