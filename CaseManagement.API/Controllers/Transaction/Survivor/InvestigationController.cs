using AutoMapper;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static CaseManagement.UtilityLibrary.EnumType;
using System;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Transaction.Survivor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class InvestigationController : ControllerBase
    {
        private readonly IInvestigation investigation;
        private readonly ILogger<SurvivorController> logger;
        private readonly IMapper mapper;

        public InvestigationController(IInvestigation investigation, ILogger<SurvivorController> logger, IMapper mapper)
        {
            this.investigation = investigation;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{survivorCode:int}")]
        public IActionResult List(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},SurvivorCode{survivorCode}");
            var result = investigation.List(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Add(InvestigationDTOAdd investigationDTOAdd)
        {
            string userName = User.Identity.Name;
            InvestigationDTOAddDB investigationDTOAddDB = mapper.Map<InvestigationDTOAddDB>(investigationDTOAdd);
            investigationDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            investigationDTOAddDB.CreatedBy = userName;
            logger.LogInformation($"|Request Argument:{investigationDTOAddDB}");
            var result = investigation.Add(investigationDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Edit(InvestigationDTOEdit investigationDTOEdit)
        {
            string userName = User.Identity.Name;
            InvestigationDTOEditDB investigationDTOEditDB = mapper.Map<InvestigationDTOEditDB>(investigationDTOEdit);
            investigationDTOEditDB.ModifiedByIpAddress = GetIPAddress(Request);
            investigationDTOEditDB.ModifiedBy = userName;
            logger.LogInformation($"|Request Argument:{investigationDTOEditDB}");
            var result = investigation.Edit(investigationDTOEditDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpPost]
        [Route("{investigationCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int investigationCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request User:{userName},IP:{iPAddress},InvestigationCode:{investigationCode}");
            var result = investigation.Delete(investigationCode, userName, iPAddress);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{investigationCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Detail(int investigationCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},InvestigationCode:{investigationCode}");
            var result = investigation.Detail(investigationCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{investigationCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangeLog_GetById(int investigationCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},InvestigationCode:{investigationCode}");
            var result = investigation.ChangeLog_GetById(investigationCode, userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [Route("{survivorCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletedList(int survivorCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = investigation.DeletedList(userName, survivorCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult OfficerChange(InvestigationOfficerChangeDTOAdd investigationOfficerChangeDTOAdd)
        {
            string userName = User.Identity.Name;
            InvestigationOfficerChangeDTOAddDB investigationOfficerChangeDTOAddDB = mapper.Map<InvestigationOfficerChangeDTOAddDB>(investigationOfficerChangeDTOAdd);
            investigationOfficerChangeDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            investigationOfficerChangeDTOAddDB.CreatedBy = userName;
            investigationOfficerChangeDTOAddDB.ChangeDate = investigationOfficerChangeDTOAdd.ChangeDate?.ToLocalTime();
            logger.LogInformation($"|Request Argument:{investigationOfficerChangeDTOAddDB}");
            var result = investigation.OfficerChange(investigationOfficerChangeDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult AgencyChange(InvestigationAgencyChangeDTOAdd investigationAgencyChangeDTOAdd)
        {
            string userName = User.Identity.Name;
            InvestigationAgencyChangeDTOAddDB investigationAgencyChangeDTOAddDB = mapper.Map<InvestigationAgencyChangeDTOAddDB>(investigationAgencyChangeDTOAdd);
            investigationAgencyChangeDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            investigationAgencyChangeDTOAddDB.CreatedBy = userName;
            investigationAgencyChangeDTOAddDB.ChangeDate = investigationAgencyChangeDTOAdd.ChangeDate?.ToLocalTime();
            logger.LogInformation($"|Request Argument:{investigationAgencyChangeDTOAddDB}");
            var result = investigation.AgencyChange(investigationAgencyChangeDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult StatusChange(InvestigationStatusChangeDTOAdd investigationStatusChangeDTOAdd)
        {
            string userName = User.Identity.Name;
            InvestigationStatusChangeDTOAddDB investigationStatusChangeDTOAddDB = mapper.Map<InvestigationStatusChangeDTOAddDB>(investigationStatusChangeDTOAdd);
            investigationStatusChangeDTOAddDB.CreatedByIpAddress = GetIPAddress(Request);
            investigationStatusChangeDTOAddDB.CreatedBy = userName;
            investigationStatusChangeDTOAddDB.ResultDate = investigationStatusChangeDTOAdd.ResultDate?.ToLocalTime();
            logger.LogInformation($"|Request Argument:{investigationStatusChangeDTOAddDB}");
            var result = investigation.StatusChange(investigationStatusChangeDTOAddDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Acceptance(InvestigationAcceptanceDTOUpdate investigationAcceptanceDTOUpdate)
        {
            string userName = User.Identity.Name;
            InvestigationAcceptanceDTOUpdateDB investigationAcceptanceDTOUpdateDB = mapper.Map<InvestigationAcceptanceDTOUpdateDB>(investigationAcceptanceDTOUpdate);
            investigationAcceptanceDTOUpdateDB.AcceptanceReasonData = investigationAcceptanceDTOUpdate.IsAccepted ? GetXMLString(investigationAcceptanceDTOUpdate.InvestigationAcceptanceMappingDTOAdd) : null;
            investigationAcceptanceDTOUpdateDB.AcceptanceByIpAddress = GetIPAddress(Request);
            investigationAcceptanceDTOUpdateDB.AcceptanceBy = userName;
            investigationAcceptanceDTOUpdateDB.AcceptanceDate = investigationAcceptanceDTOUpdate.AcceptanceDate?.ToLocalTime();
            logger.LogInformation($"|Request Argument:{investigationAcceptanceDTOUpdateDB}");
            var result = investigation.Acceptance(investigationAcceptanceDTOUpdateDB);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}