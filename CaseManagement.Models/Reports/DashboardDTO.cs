using CaseManagement.Models.Common;
using System.Collections.Generic;

namespace CaseManagement.Models.Reports
{
    public class DashboardDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public ReportSurvivorDTO ReportSurvivorDTO { get; set; }
        public List<ReportPoliceStationDTOList> ReportPoliceStationDTOList { get; set; }
        public List<ReportInvestigationListByAgency> ReportInvestigationListByAgency { get; set; }
        public ReportInvestigationByStatus ReportInvestigationByStatus { get; set; }
        public ReportSurvivorByState ReportSurvivorByState { get; set; }
        public ReportInvestigationByResult ReportInvestigationByResult { get; set; }
        public ReportVcDTO ReportVcDTO { get; set; }
        public ReportTotalVCByResult ReportTotalVCByResult { get; set; }
        public List<ReportVCDTOListByResult> ReportVCDTOListByResult { get; set; }
        public List<ReportTafteeshStatusListByResult> ReportTafteeshStatusListByResult { get; set; }
        public ReportCITDTOListByResult ReportCITDTOListByResults { get; set; }
        public ReportPCDTO ReportPCDTO { get; set; }
        public List<ReportPCByReference> ReportPCByReference { get; set; }
    }

    public class ReportSurvivorDTO
    {
        public int TotalSurvivor { get; set; }
    }

    public class ReportPoliceStationDTOList
    {
        public string PoliceStationName { get; set; }
        public int TotalSurvivor { get; set; }
        public int firCount { get; set; }
        public int investigationCount { get; set; }
    }

    public class ReportInvestigationListByAgency
    {
        public string InvestingAgencyType { get; set; }
        public int TotalSurvivor { get; set; }
    }

    public class ReportInvestigationByStatus
    {
        public int OnGoingCount { get; set; }
        public int CompletedCount { get; set; }
        public int TotalCount { get; set; }
    }

    public class ReportSurvivorByState
    {
        public int IntraStateCount { get; set; }
        public int InterStateCount { get; set; }
    }

    public class ReportInvestigationByResult
    {
        public int FrtCount { get; set; }
        public int ChargesheetCount { get; set; }
    }

    public class ReportVcDTO
    {
        public int AppliedCount { get; set; }
        public int NotAppliedCount { get; set; }
    }

    public class ReportTotalVCByResult
    {
        public int TotalVc { get; set; }
        public int OnGoingCount { get; set; }
        public int AwardedCount { get; set; }
        public int RejectedCount { get; set; }
        public int ConcludedCount { get; set; }
    }

    public class ReportTafteeshStatusListByResult
    {
        public int TafteeshStatusCode { get; set; }
        public string TafteeshStatus { get; set; }
        public int TotalCount { get; set; }
    }

    public class ReportVCDTOListByResult
    {
        public string SaDa { get; set; }
        public int OnGoingCount { get; set; }
        public int AwardedCount { get; set; }
        public int RejectedCount { get; set; }
    }

    public class ReportCITDTOListByResult
    {
        public int TotalCitCount { get; set; }
        public int PendingCount { get; set; }
        public int ApprovedCount { get; set; }
    }

    public class ReportPCDTO
    {
        public int TotalPc { get; set; }
        public int AllowedCount { get; set; }
        public int NotAllowedCount { get; set; }
        public int OnGoingCount { get; set; }
        public int CompletedCount { get; set; }
    }
    public class ReportPCByReference
    {
        public string ReferenceRecordType { get; set; }
        public int TotalCount { get; set; }
    }
}