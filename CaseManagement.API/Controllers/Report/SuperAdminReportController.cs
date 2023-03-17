using AutoMapper;
using CaseManagement.API.Controllers.Reports;
using CaseManagement.Models.Admin;
using CaseManagement.Repository.Interfaces;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using static CaseManagement.UtilityLibrary.Utility;

namespace CaseManagement.API.Controllers.Report
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SuperAdminReportController : ControllerBase
    {
        private readonly ISuperAdminReport superAdminReport;
        private readonly ILogger<SuperAdminReportController> logger;
        private readonly IMapper mapper;
        private readonly IConverter converter;
        public SuperAdminReportController(ISuperAdminReport superAdminReport, ILogger<SuperAdminReportController> logger, IMapper mapper, IConverter converter)
        {
            this.superAdminReport = superAdminReport;
            this.logger = logger;
            this.mapper = mapper;
            this.converter = converter;
        }
        [HttpGet]
        [Route("{StartDate}/{EndDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult LogInHistory_Admin(DateTime StartDate, DateTime EndDate)
        {
            //var parsedSDate = DateTime.Parse(StartDate);
            //var parsedEDate = DateTime.Parse(EndDate);
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            DateTime SDate = StartDate.ToLocalTime();
            DateTime EDate = EndDate.ToLocalTime();
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = superAdminReport.LogInHistory_OverAllReport_Admin(SDate,EDate,userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}
