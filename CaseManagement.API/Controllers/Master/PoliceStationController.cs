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
    public class PoliceStationController : ControllerBase
    {
        private readonly IPoliceStation policeStation;
        private readonly ILogger<PoliceStationController> logger;
        private readonly IMapper mapper;


        public PoliceStationController(IPoliceStation policeStation, ILogger<PoliceStationController> logger, IMapper mapper)
        {
            this.policeStation = policeStation;
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
            var result = policeStation.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(PoliceStationDTOAdd policeStationDTOAdd)
        {
            string userName = User.Identity.Name;
            PoliceStationDTOAddDB policeStationDTOAddDB = mapper.Map<PoliceStationDTOAddDB>(policeStationDTOAdd);
            policeStationDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            policeStationDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{policeStationDTOAddDB}");
            var result = policeStation.Add(policeStationDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(PoliceStationDTOEdit policeStationDTOEdit)
        {
            string userName = User.Identity.Name;
            PoliceStationDTOEditDB policeStationDTOEditDB = mapper.Map<PoliceStationDTOEditDB>(policeStationDTOEdit);
            policeStationDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            policeStationDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{policeStationDTOEditDB}");
            var result = policeStation.Edit(policeStationDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{policeStationCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int policeStationCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},PoliceStationCode:{policeStationCode}");
            var result = policeStation.Delete(policeStationCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{policeStationCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int policeStationCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},PoliceStationCode:{policeStationCode}");
            var result = policeStation.Detail(policeStationCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{policeStationCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int policeStationCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},PoliceStationCode:{policeStationCode}");
            var result = policeStation.ChangeLog_GetById(policeStationCode, userName);
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
            var result = policeStation.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

    }
}
