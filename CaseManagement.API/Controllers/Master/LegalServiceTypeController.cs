using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using CaseManagement.UtilityLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LegalServiceTypeController : ControllerBase
    {
        private readonly ILegalServiceType legalServiceType;
        private readonly ILogger<LegalServiceTypeController> logger;
        private readonly IMapper mapper;

        public LegalServiceTypeController(ILegalServiceType legalServiceType, ILogger<LegalServiceTypeController> logger, IMapper mapper)
        {
            this.legalServiceType = legalServiceType;
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
            var result = legalServiceType.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(LegalServiceTypeDTOAdd legalServiceTypeDTOAdd)
        {
            string userName = User.Identity.Name;
            LegalServiceTypeDTOAddDB legalServiceTypeDTOAddDB = mapper.Map<LegalServiceTypeDTOAddDB>(legalServiceTypeDTOAdd);
            string dataXmlProgramAxis = Utility.GetXMLString(legalServiceTypeDTOAdd.ProgramAxisData);
            legalServiceTypeDTOAddDB.ProgramAxisData = dataXmlProgramAxis;
            legalServiceTypeDTOAddDB.CreatedByIpAddress = Utility.GetIPAddress(Request);
            legalServiceTypeDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{legalServiceTypeDTOAddDB}");
            var result = legalServiceType.Add(legalServiceTypeDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(LegalServiceTypeDTOEdit legalServiceTypeDTOEdit)
        {
            string userName = User.Identity.Name;
            LegalServiceTypeDTOEditDB legalServiceTypeDTOEditDB = mapper.Map<LegalServiceTypeDTOEditDB>(legalServiceTypeDTOEdit);
            string dataXmlProgramAxis = Utility.GetXMLString(legalServiceTypeDTOEdit.ProgramAxisData);
            legalServiceTypeDTOEditDB.ProgramAxisData = dataXmlProgramAxis;
            legalServiceTypeDTOEditDB.ModifiedByIpAddress = Utility.GetIPAddress(Request);
            legalServiceTypeDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{legalServiceTypeDTOEditDB}");
            var result = legalServiceType.Edit(legalServiceTypeDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{legalServiceTypeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int legalServiceTypeCode)
        {
            string userName = User.Identity.Name;//"Man@1";
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},LegalServiceTypeCode:{legalServiceTypeCode}");
            var result = legalServiceType.Delete(legalServiceTypeCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{legalServiceTypeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int legalServiceTypeCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},LegalServiceTypeCode:{legalServiceTypeCode}");
            var result = legalServiceType.Detail(legalServiceTypeCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{legalServiceTypeCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int legalServiceTypeCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = Utility.GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},LegalServiceTypeCode:{legalServiceTypeCode}");
            var result = legalServiceType.ChangeLog_GetById(legalServiceTypeCode, userName);
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
            var result = legalServiceType.DeletedList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}