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
    public class CityController : ControllerBase
    {
        private readonly ICity city;
        private readonly ILogger<CityController> logger;
        private readonly IMapper mapper;
        public CityController(ICity city, ILogger<CityController> logger, IMapper mapper)
        {
            this.city = city;
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
            var result = city.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(CityDTOAdd cityDTOAdd)
        {
            string userName = User.Identity.Name;
            CityDTOAddDB cityDTOAddDB = mapper.Map<CityDTOAddDB>(cityDTOAdd);
            cityDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            cityDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"Request Argument:{cityDTOAddDB}");
            var result = city.Add(cityDTOAddDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(CityDTOEdit cityDTOEdit)
        {
            string userName = User.Identity.Name;
            CityDTOEditDB cityDTOEditDB = mapper.Map<CityDTOEditDB>(cityDTOEdit);
            cityDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            cityDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"Request Argument:{cityDTOEditDB}");
            var result = city.Edit(cityDTOEditDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{cityCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int cityCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request: UserName:{userName},IP:{iPAddress},CityCode:{cityCode}");
            var result = city.Detail(cityCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{cityCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int cityCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|request User: {userName},IP:{iPAddress},CityCode:{cityCode}");
            var result = city.Delete(cityCode, userName, iPAddress);
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
            var result = city.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
       
        [HttpGet]
        [Route("{cityCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int cityCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},CityCode:{cityCode}");
            var result = city.ChangeLog_GetById(cityCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}
