using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
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
    public class LawyerTypeController : ControllerBase
    {
        private readonly ILawyerType lawyerType;
        private readonly ILogger<LawyerTypeController> logger;
        private readonly IMapper mapper;

        public LawyerTypeController(ILawyerType lawyerType, ILogger<LawyerTypeController> logger, IMapper mapper)
        {
            this.lawyerType = lawyerType;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(LawyerTypeDTOAdd lawyerTypeDTOAdd)
        {
            string userName = User.Identity.Name;
            LawyerTypeDTOAddDB lawyerTypeDTOAddDB = mapper.Map<LawyerTypeDTOAddDB>(lawyerTypeDTOAdd);
            lawyerTypeDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            lawyerTypeDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{lawyerTypeDTOAddDB}");
            var result = lawyerType.Add(lawyerTypeDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(LawyerTypeDTOEdit lawyerTypeDTOEdit)
        {
            string userName = User.Identity.Name;
            LawyerTypeDTOEditDB lawyerTypeDTOEditDB = mapper.Map<LawyerTypeDTOEditDB>(lawyerTypeDTOEdit);
            lawyerTypeDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            lawyerTypeDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{lawyerTypeDTOEditDB}");
            var result = lawyerType.Edit(lawyerTypeDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = lawyerType.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{lawyerTypeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int lawyerTypeCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},LawyerTypeCode:{lawyerTypeCode}");
            var result = lawyerType.Detail(lawyerTypeCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{lawyerTypeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int lawyerTypeCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},LawyerTypeCode:{lawyerTypeCode},UserName:{userName}");
            var result = lawyerType.ChangeLog_GetById(lawyerTypeCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{lawyerTypeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int lawyerTypeCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},LawyerTypeCode:{lawyerTypeCode}");
            var result = lawyerType.Delete(lawyerTypeCode, userName, iPAddress);
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
            var result = lawyerType.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}