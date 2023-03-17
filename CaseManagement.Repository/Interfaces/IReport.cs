using CaseManagement.Models.Admin;
using CaseManagement.Models.Reports;

namespace CaseManagement.Repository.Interfaces
{
    public interface IReport
    {
        DashboardDTOResponse DashBoardReport(string userName);
        VCRegisterResponse VCRegisterReport(string userName);
        PCRegisterResponse PCRegisterReport(string userName);
        SurvivorRegisterResponse survivorRegisterReport(string userName);
        FIRRegisterResponse firRegisterReport(string userName);
        CITRegisterResponse citRegisterReport(string userName);
        MonthlyReportDTOResponse MonthlyReportList(string userName);
        MonthlyReportDTODetailResponse MonthlyReportGetByCode(string userName,int ScheduleMemberCode);
    }
}