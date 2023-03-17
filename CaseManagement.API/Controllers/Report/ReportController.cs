using AutoMapper;
using CaseManagement.Repository.Interfaces;
using DinkToPdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System;
using static CaseManagement.UtilityLibrary.Utility;
using System.Net;
using DinkToPdf.Contracts;
using System.Linq;
using static CaseManagement.UtilityLibrary.EnumType;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Reports;

namespace CaseManagement.API.Controllers.Reports
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IReport report;
        private readonly ILogger<ReportController> logger;
        private readonly IMapper mapper;
        private readonly IConverter converter;

        public ReportController(IReport report, ILogger<ReportController> logger, IMapper mapper, IConverter converter)
        {
            this.report = report;
            this.logger = logger;
            this.mapper = mapper;
            this.converter = converter;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = report.DashBoardReport(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult VCRegisterList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = report.VCRegisterReport(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult PCRegisterList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = report.PCRegisterReport(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SurvivorRegisterList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = report.survivorRegisterReport(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult FIRRegisterList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = report.firRegisterReport(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CITRegisterList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = report.citRegisterReport(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult MonthlyReportList()
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = report.MonthlyReportList(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{scheduleMemberCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult MonthlyReportList(int scheduleMemberCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},ScheduleMemberCode:{scheduleMemberCode}");
            var result = report.MonthlyReportGetByCode(userName, scheduleMemberCode);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{scheduleMemberCode:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DownloadMonthlyReport(int scheduleMemberCode)
        {
            string userName = User.Identity.Name;
            string iPAddress = GetIPAddress(Request);
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress},ScheduleMemberCode:{scheduleMemberCode}");
            var result = report.MonthlyReportGetByCode(userName, scheduleMemberCode);
            var htmlpath = Path.Combine(Directory.GetCurrentDirectory(), "ReportHtml", "MonthlyReport.html");
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Monthly Report"
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings
            };
            var html = new StringBuilder(System.IO.File.ReadAllText(htmlpath));
            if (result.DataUpdateResponse.Status)
            {
                //For Header Start
                StringBuilder strTafteeshStatus = new StringBuilder();
                html.Replace("#MEMBERNAME", result.ScheduleMemberDTO.MemberName);
                html.Replace("#ORGANIZATION", result.ScheduleMemberDTO.Organization);
                html.Replace("#DURATION", result.ScheduleMemberDTO.Duration);
                html.Replace("#TOTALSURVIVORS", Convert.ToString(result.ScheduleMemberDTO.TotalSurvivor));
                //For Header End

                //For Tafteesh Log List
                for (var i = 0; i < result.ScheduleTafteeshDTODetail.Count; i++)
                {
                    strTafteeshStatus.Append("<tr>");
                    strTafteeshStatus.Append("<td style=text-align:left;>").Append(result.ScheduleTafteeshDTODetail[i].TafteeshStatusLog).Append("</td>");
                    strTafteeshStatus.Append("<td style=text-align:right;>").Append(result.ScheduleTafteeshDTODetail[i].Total).Append("</td>");
                    strTafteeshStatus.Append("</tr>");
                }
                html.Replace("#TAFTEESHSUMMARY", Convert.ToString(strTafteeshStatus));
                //For Tafteesh Log List End

                //For VC PC Section Start
                StringBuilder strVcPcDetails = new StringBuilder();
                for (var i = 0; i < result.ScheduleVcPcDTODetail.Count; i++)
                {
                    strVcPcDetails.Append("<tr>");
                    strVcPcDetails.Append("<td style=text-align:left;>").Append(result.ScheduleVcPcDTODetail[i].SurvivorName).Append("</td>");
                    strVcPcDetails.Append("<td style=text-align:left;>").Append(result.ScheduleVcPcDTODetail[i].PC_SA_Count).Append("</td>");
                    strVcPcDetails.Append("<td style=text-align:left;>").Append(result.ScheduleVcPcDTODetail[i].PC_DA_Count).Append("</td>");
                    strVcPcDetails.Append("<td style=text-align:left;>").Append(result.ScheduleVcPcDTODetail[i].VC_Count).Append("</td>");
                    strVcPcDetails.Append("<td style=text-align:left;>").Append(result.ScheduleVcPcDTODetail[i].Rehabilitation_Count).Append("</td>");
                    strVcPcDetails.Append("</tr>");
                }
                html.Replace("#VCPCDETAIL", Convert.ToString(strVcPcDetails));

                var vcSummary = result.ScheduleVCDTOSummary;

                html.Replace("#VCOVERALL", Convert.ToString((vcSummary?.VCOverAll) ?? 0));
                html.Replace("#VCTHISMONTH", Convert.ToString((vcSummary?.VCThisMonth) ?? 0));

                StringBuilder strVcResult = new StringBuilder();
                for (var i = 0; i < result.ScheduleVcResultWiseDTO.Count; i++)
                {
                    strVcResult.Append("<tr>");
                    strVcResult.Append("<td style=text-align:left;>").Append(result.ScheduleVcResultWiseDTO[i].VCResult).Append("</td>");
                    strVcResult.Append("<td style=text-align:left;>").Append(result.ScheduleVcResultWiseDTO[i].IsCurrent).Append("</td>");
                    strVcResult.Append("<td style=text-align:right;>").Append(result.ScheduleVcResultWiseDTO[i].Total).Append("</td>");
                    strVcResult.Append("</tr>");
                }
                html.Replace("#VCRESULTSUMMARY", Convert.ToString(strVcResult));
                //For VC PC Section END


                //For EngagementSummary Start
                StringBuilder strEngagementSurvivorList = new StringBuilder();
                for (var i = 0; i < result.ScheduleEngagementSurvivorList.Count; i++)
                {
                    strEngagementSurvivorList.Append("<tr>");
                    strEngagementSurvivorList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementSurvivorList[i].RelatedTo).Append("</td>");
                    strEngagementSurvivorList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementSurvivorList[i].MeetingLocation).Append("</td>");
                    strEngagementSurvivorList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementSurvivorList[i].MeetingMode).Append("</td>");
                    strEngagementSurvivorList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementSurvivorList[i].Status).Append("</td>");
                    strEngagementSurvivorList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementSurvivorList[i].PlanToCloseOn).Append("</td>");
                    strEngagementSurvivorList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementSurvivorList[i].ClosedOn).Append("</td>");
                    strEngagementSurvivorList.Append("</tr>");
                }
                html.Replace("#ENGAGEMENTSURVIVORLIST", Convert.ToString(strEngagementSurvivorList));

                //For Survivor MeetingList Start
                StringBuilder strSurvivorMeetingList = new StringBuilder();
                for (var i = 0; i < result.ScheduleSurvivorMeetingDTO.Count; i++)
                {
                    strSurvivorMeetingList.Append("<tr>");
                    strSurvivorMeetingList.Append("<td style=text-align:left;>").Append(result.ScheduleSurvivorMeetingDTO[i].SurvivorName).Append("</td>");
                    strSurvivorMeetingList.Append("<td style=text-align:left;>").Append(result.ScheduleSurvivorMeetingDTO[i].LastMeetingOn).Append("</td>");
                    strSurvivorMeetingList.Append("<td style=text-align:right;>").Append(result.ScheduleSurvivorMeetingDTO[i].DaysSinceLastMeeting).Append("</td>");
                    strSurvivorMeetingList.Append("</tr>");
                }
                html.Replace("#SURVIVORMEETINGLIST", Convert.ToString(strSurvivorMeetingList));
                //For Survivor MeetingList End

                StringBuilder strEngagementStackHolderList = new StringBuilder();
                for (var i = 0; i < result.ScheduleEngagementStackHolderList.Count; i++)
                {
                    strEngagementStackHolderList.Append("<tr>");
                    strEngagementStackHolderList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementStackHolderList[i].RelatedTo).Append("</td>");
                    strEngagementStackHolderList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementStackHolderList[i].MeetingLocation).Append("</td>");
                    strEngagementStackHolderList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementStackHolderList[i].MeetingMode).Append("</td>");
                    strEngagementStackHolderList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementStackHolderList[i].Status).Append("</td>");
                    strEngagementStackHolderList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementStackHolderList[i].PlanToCloseOn).Append("</td>");
                    strEngagementStackHolderList.Append("<td style=text-align:left;>").Append(result.ScheduleEngagementStackHolderList[i].ClosedOn).Append("</td>");
                    strEngagementStackHolderList.Append("</tr>");
                }
                html.Replace("#ENGAGEMENTSTACKHOLDERLIST", Convert.ToString(strEngagementStackHolderList));

                //For StackHolder MeetingList Start
                StringBuilder strStackHolderMeetingList = new StringBuilder();
                for (var i = 0; i < result.ScheduleStackHolderMeetingDTO.Count; i++)
                {
                    strStackHolderMeetingList.Append("<tr>");
                    strStackHolderMeetingList.Append("<td style=text-align:left;>").Append(result.ScheduleStackHolderMeetingDTO[i].StackHolderName).Append("</td>");
                    strStackHolderMeetingList.Append("<td style=text-align:left;>").Append(result.ScheduleStackHolderMeetingDTO[i].LastMeetingOn).Append("</td>");
                    strStackHolderMeetingList.Append("<td style=text-align:right;>").Append(result.ScheduleStackHolderMeetingDTO[i].DaysSinceLastMeeting).Append("</td>");
                    strStackHolderMeetingList.Append("</tr>");
                }
                html.Replace("#STACKHOLDERMEETINGLIST", Convert.ToString(strStackHolderMeetingList));
                //For Survivor MeetingList End
                //For EngagementSummary End

                //For Investigation TypeWise Start
                StringBuilder strInvestigationTypeList = new StringBuilder();
                for (var i = 0; i < result.ScheduleInvetigationTypeDTO.Count; i++)
                {
                    strInvestigationTypeList.Append("<tr>");
                    strInvestigationTypeList.Append("<td style=text-align:left;>").Append(result.ScheduleInvetigationTypeDTO[i].InvestingAgencyType).Append("</td>");
                    strInvestigationTypeList.Append("<td style=text-align:right;>").Append(result.ScheduleInvetigationTypeDTO[i].Total).Append("</td>");
                    strInvestigationTypeList.Append("</tr>");
                }
                html.Replace("#INVESTIGATIONTYPELIST", Convert.ToString(strInvestigationTypeList));
                //For Investigation TypeWise End
                //For Investigation Transfer Agency Start
                StringBuilder strInvestigationTransferAgencyList = new StringBuilder();
                for (var i = 0; i < result.ScheduleInvetigationAgencyTransferDTO.Count; i++)
                {
                    strInvestigationTransferAgencyList.Append("<tr>");
                    strInvestigationTransferAgencyList.Append("<td style=text-align:left;>").Append(result.ScheduleInvetigationAgencyTransferDTO[i].SurvivorName).Append("</td>");
                    strInvestigationTransferAgencyList.Append("<td style=text-align:left;>").Append(result.ScheduleInvetigationAgencyTransferDTO[i].From).Append("</td>");
                    strInvestigationTransferAgencyList.Append("<td style=text-align:left;>").Append(result.ScheduleInvetigationAgencyTransferDTO[i].To).Append("</td>");
                    strInvestigationTransferAgencyList.Append("</tr>");
                }
                html.Replace("#INVESTIGATIONTRANSFERLIST", Convert.ToString(strInvestigationTransferAgencyList));
                //For Investigation Transfer Agency Start

            }
            else
            {
                html.Clear();
                html.Append("<h1>").Append(result.DataUpdateResponse.Description).Append("</h1>");
            }
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = html.ToString(),
                //WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "ReportHtml\\Assets", "PaySlip_styles.css") },
                WebSettings = { DefaultEncoding = "utf-8" },
                FooterSettings = { FontName = "Times", FontSize = 9, Line = false, Left = "Print Date: " + DateTime.Now.ToString("dd-MMMM-yyyy") }
            };
            pdf.Objects.Add(objectSettings);
            byte[] FileBytes = converter.Convert(pdf);
            logger.LogInformation($"ReportIndividual | Result: {result}");
            return File(FileBytes, "application/pdf", "MonthlyReport_" + result.ScheduleMemberDTO.Duration + ".pdf");
        }
    }
}