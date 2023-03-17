using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Cit
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class DimensionController : ControllerBase
    {
        private readonly IDimension dimension;
        private readonly ILogger<DimensionController> logger;
        private readonly IMapper mapper;

        public DimensionController(IDimension dimension, ILogger<DimensionController> logger, IMapper mapper)
        {
            this.dimension = dimension;
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
            var result = dimension.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(DimensionDTOAdd dimensionDTOAdd)
        {
            string userName = User.Identity.Name;
            DimensionDTOAddDB dimensionDTOAddDB = mapper.Map<DimensionDTOAddDB>(dimensionDTOAdd);
            dimensionDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            dimensionDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{dimensionDTOAddDB}");
            var result = dimension.Add(dimensionDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(DimensionDTOEdit dimensionDTOEdit)
        {
            string userName = User.Identity.Name;
            DimensionDTOEditDB dimensionDTOEditDB = mapper.Map<DimensionDTOEditDB>(dimensionDTOEdit);
            dimensionDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            dimensionDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{dimensionDTOEditDB}");
            var result = dimension.Edit(dimensionDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{dimensionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Obsolete(int dimensionCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},DimensionCode:{dimensionCode}");
            var result = dimension.Obsolete(dimensionCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{dimensionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int dimensionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},DimensionCode:{dimensionCode}");
            var result = dimension.Detail(dimensionCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{dimensionCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int dimensionCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},DimensionCode:{dimensionCode}");
            var result = dimension.ChangeLog_GetById(dimensionCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ObsoleteList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = dimension.ObsoleteList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}