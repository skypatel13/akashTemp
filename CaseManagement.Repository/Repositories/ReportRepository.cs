using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Models.Reports;
using CaseManagement.Repository.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CaseManagement.Repository.Repositories
{
    public class ReportRepository : IReport
    {
        private readonly AppConnectionString appConnectionString;
        public ReportRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public DashboardDTOResponse DashBoardReport(string userName)
        {
            DashboardDTOResponse dashboardDTOResponse = new DashboardDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Reports_Dashboard", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    dashboardDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (dashboardDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        dashboardDTOResponse.ReportSurvivorDTO = result.Read<ReportSurvivorDTO>().FirstOrDefault();
                        dashboardDTOResponse.ReportPoliceStationDTOList = result.Read<ReportPoliceStationDTOList>().ToList();
                        dashboardDTOResponse.ReportInvestigationListByAgency = result.Read<ReportInvestigationListByAgency>().ToList();
                        dashboardDTOResponse.ReportInvestigationByStatus = result.Read<ReportInvestigationByStatus>().FirstOrDefault();
                        dashboardDTOResponse.ReportSurvivorByState = result.Read<ReportSurvivorByState>().FirstOrDefault();
                        dashboardDTOResponse.ReportInvestigationByResult = result.Read<ReportInvestigationByResult>().FirstOrDefault();
                        dashboardDTOResponse.ReportVcDTO = result.Read<ReportVcDTO>().FirstOrDefault();
                        dashboardDTOResponse.ReportTotalVCByResult = result.Read<ReportTotalVCByResult>().FirstOrDefault();
                        dashboardDTOResponse.ReportVCDTOListByResult = result.Read<ReportVCDTOListByResult>().ToList();
                        dashboardDTOResponse.ReportTafteeshStatusListByResult = result.Read<ReportTafteeshStatusListByResult>().ToList();
                        dashboardDTOResponse.ReportCITDTOListByResults = result.Read<ReportCITDTOListByResult>().FirstOrDefault();
                        dashboardDTOResponse.ReportPCDTO = result.Read<ReportPCDTO>().FirstOrDefault();
                        dashboardDTOResponse.ReportPCByReference = result.Read<ReportPCByReference>().ToList();
                    }
                }
            }
            return dashboardDTOResponse;
        }
        public VCRegisterResponse VCRegisterReport(string userName)
        {
            VCRegisterResponse vcRegisterResponse = new VCRegisterResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("RegisterReport_VC_GetByUserName", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    vcRegisterResponse.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (vcRegisterResponse.dataUpdateResponseDTO.Status)
                {
                    if (!result.IsConsumed)
                    {
                        vcRegisterResponse.vcRegisterReports = result.Read<VCRegisterReport>().ToList();
                    }
                }
            }
            return vcRegisterResponse;
        }
        public PCRegisterResponse PCRegisterReport(string userName)
        {
            PCRegisterResponse pcRegisterResponse = new PCRegisterResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("RegisterReport_PC_GetByUserName", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    pcRegisterResponse.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (pcRegisterResponse.dataUpdateResponseDTO.Status)
                {
                    if (!result.IsConsumed)
                    {
                        pcRegisterResponse.pcRegisterReports = result.Read<dynamic>().ToList();
                    }
                }
            }
            return pcRegisterResponse;
        }
        public SurvivorRegisterResponse survivorRegisterReport(string userName)
        {
            SurvivorRegisterResponse survivorRegisterResponse = new SurvivorRegisterResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("RegisterReport_Survivor_GetByUserName", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorRegisterResponse.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorRegisterResponse.dataUpdateResponseDTO.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorRegisterResponse.survivorRegisterReports = result.Read<SurvivorRegisterReport>().ToList();
                    }
                }
            }
            return survivorRegisterResponse;
        }
        public FIRRegisterResponse firRegisterReport(string userName)
        {
            FIRRegisterResponse fIRRegisterResponse = new FIRRegisterResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("RegisterReport_FIR_GetByUserName", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    fIRRegisterResponse.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (fIRRegisterResponse.dataUpdateResponseDTO.Status)
                {
                    if (!result.IsConsumed)
                    {
                        fIRRegisterResponse.fIRRegisterReports = result.Read<FIRRegisterReport>().ToList();
                    }
                }
            }
            return fIRRegisterResponse;
        }
        public CITRegisterResponse citRegisterReport(string userName)
        {
            CITRegisterResponse citRegisterResponse = new CITRegisterResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("RegisterReport_CIT_GetByUserName", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    citRegisterResponse.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (citRegisterResponse.dataUpdateResponseDTO.Status)
                {
                    if (!result.IsConsumed)
                    {
                        citRegisterResponse.citRegisterReports = result.Read<CITRegisterReport>().ToList();
                    }
                }
            }
            return citRegisterResponse;
        }
        public MonthlyReportDTOResponse MonthlyReportList(string userName)
        {
            MonthlyReportDTOResponse monthlyReportDTOResponse = new MonthlyReportDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("MonthlyReport_List_GetByMemberCode", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    monthlyReportDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (monthlyReportDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTOResponse.MonthlyReportDTOList = result.Read<MonthlyReportDTOList>().ToList();
                    }
                }
            }
            return monthlyReportDTOResponse;
        }
        public MonthlyReportDTODetailResponse MonthlyReportGetByCode(string userName, int scheduleMemberCode)
        {
            MonthlyReportDTODetailResponse monthlyReportDTODetailResponse = new MonthlyReportDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("MonthlyReport_GetByCode_Admin", new { UserName = userName, ScheduleMemberCode = scheduleMemberCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    monthlyReportDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (monthlyReportDTODetailResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTODetailResponse.ScheduleMemberDTO = result.Read<ScheduleMemberDTO>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTODetailResponse.ScheduleVcPcDTODetail = result.Read<ScheduleVcPcDTODetail>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTODetailResponse.ScheduleTafteeshDTODetail = result.Read<ScheduleTafteeshDTODetail>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTODetailResponse.ScheduleVCDTOSummary = result.Read<ScheduleVCDTOSummary>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTODetailResponse.ScheduleVcResultWiseDTO = result.Read<ScheduleVcResultWiseDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTODetailResponse.ScheduleEngagementSurvivorList = result.Read<ScheduleEngagementSurvivorList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTODetailResponse.ScheduleSurvivorMeetingDTO = result.Read<ScheduleSurvivorMeetingDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTODetailResponse.ScheduleEngagementStackHolderList = result.Read<ScheduleEngagementSurvivorList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTODetailResponse.ScheduleStackHolderMeetingDTO = result.Read<ScheduleStackHolderMeetingDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTODetailResponse.ScheduleInvetigationTypeDTO = result.Read<ScheduleInvetigationTypeDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        monthlyReportDTODetailResponse.ScheduleInvetigationAgencyTransferDTO = result.Read<ScheduleInvetigationAgencyTransferDTO>().ToList();
                    }
                }
            }
            return monthlyReportDTODetailResponse;
        }
    }
}
