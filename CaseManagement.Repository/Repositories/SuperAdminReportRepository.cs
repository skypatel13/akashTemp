using CaseManagement.DAL;
using CaseManagement.Models.Common;
using CaseManagement.Models.Reports;
using CaseManagement.Repository.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Linq;
using CaseManagement.Models.SuperAdmin;
using System;

namespace CaseManagement.Repository.Repositories
{
    public class SuperAdminReportRepository : ISuperAdminReport
    {
        private readonly AppConnectionString appConnectionString;
        public SuperAdminReportRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public LoginHistoryDTO LogInHistory_OverAllReport_Admin(DateTime startDate, DateTime endDate, string userName)
        {
            LoginHistoryDTO loginHistoryDTO = new LoginHistoryDTO();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LogInHistory_Report_GetByDate_Admin", new { StartDate = startDate, EndDate = endDate, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    loginHistoryDTO.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (loginHistoryDTO.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        loginHistoryDTO.LoginHistoryLog = result.Read<LoginHistoryLog>().ToList();
                    }
                }
            }
            return loginHistoryDTO;
        }
    }
}
