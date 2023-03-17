using CaseManagement.Models.SuperAdmin;
using System;

namespace CaseManagement.Repository.Interfaces
{
    public interface ISuperAdminReport
    {
        LoginHistoryDTO LogInHistory_OverAllReport_Admin(DateTime startDate, DateTime endDate, string userName);
    }
}
