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
    public class DistrictController : ControllerBase
    {
        private readonly IDistrict district;
        private readonly ILogger<DistrictController> logger;
        private readonly IMapper mapper;

        public DistrictController(IDistrict district, ILogger<DistrictController> logger, IMapper mapper)
        {
            this.district = district;
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
            logger.LogInformation($"Request District List User: {userName},IP:{iPAddress}");
            var result = district.List(userName);
            logger.LogInformation($"Result District List: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(DistrictDTOAdd districtDTOAdd)
        {
            string userName = User.Identity.Name;
            DistrictDTOAddDB districtDTOAddDB = mapper.Map<DistrictDTOAddDB>(districtDTOAdd);
            districtDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            districtDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"Request District Add Argument:{districtDTOAddDB}");
            var result = district.Add(districtDTOAddDB);
            logger.LogInformation($"Result District Add {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(DistrictDTOEdit districtDTOEdit)
        {
            string userName = User.Identity.Name;
            DistrictDTOEditDB districtDTOEditDB = mapper.Map<DistrictDTOEditDB>(districtDTOEdit);
            districtDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            districtDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"Request District Add Argument:{districtDTOEditDB}");
            var result = district.Edit(districtDTOEditDB);
            logger.LogInformation($"Result District Add {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{districtCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int districtCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request District Delete User: {userName},IP:{iPAddress}, Argument:districtCode:{districtCode}");
            var result = district.Delete(districtCode, userName, iPAddress);
            logger.LogInformation($"Request District Delete Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request District Deleted List User: {userName},IP:{iPAddress}");
            var result = district.DeletedList(userName);
            logger.LogInformation($"Result District Deleted List: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{districtCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int districtCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"Request Collective Detail User: {userName},IP:{iPAddress}, Argument:districtCode:{districtCode}");
            var result = district.Detail(districtCode, userName);
            logger.LogInformation($"Result Collective Detail: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{districtCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int districtCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},DistrictCode:{districtCode}");
            var result = district.ChangeLog_GetById(districtCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}