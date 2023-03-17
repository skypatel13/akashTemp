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
    public class BlockController : ControllerBase
    {
        private readonly IBlock block;
        private readonly ILogger<BlockController> logger;
        private readonly IMapper mapper;

        public BlockController(IBlock block, ILogger<BlockController> logger, IMapper mapper)
        {
            this.block = block;
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
            var result = block.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(BlockDTOAdd blockDTOAdd)
        {
            string userName = User.Identity.Name;
            BlockDTOAddDB blockDTOAddDB = mapper.Map<BlockDTOAddDB>(blockDTOAdd);
            blockDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            blockDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"Request Argument:{blockDTOAddDB}");
            var result = block.Add(blockDTOAddDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(BlockDTOEdit blockDTOEdit)
        {
            string userName = User.Identity.Name;
            BlockDTOEditDB blockDTOEditDB = mapper.Map<BlockDTOEditDB>(blockDTOEdit);
            blockDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            blockDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"Request Argument:{blockDTOEditDB}");
            var result = block.Edit(blockDTOEditDB);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{blockCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int blockCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request: UserName:{userName},IP:{iPAddress},BlockCode:{blockCode}");
            var result = block.Detail(blockCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{blockCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int blockCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|request User: {userName},IP:{iPAddress},BlockCode:{blockCode}");
            var result = block.Delete(blockCode, userName, iPAddress);
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
            var result = block.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        //[HttpGet]
        //[Route("{districtCode:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public IActionResult GetByDistrictId(int districtCode)
        //{
        //    string userName = User.Identity.Name;
        //    string iPAddress = Utility.GetIPAddress(Request);
        //    logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},DistrictCode:{districtCode}");
        //    var result = block.GetByDistrictId(districtCode, userName);
        //    logger.LogInformation($"|Result: {result}");
        //    return Ok(result);
        //}
        [HttpGet]
        [Route("{blockCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int blockCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},BlockCode:{blockCode}");
            var result = block.ChangeLog_GetById(blockCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

    }
}
