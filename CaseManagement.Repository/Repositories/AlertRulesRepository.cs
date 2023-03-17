using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;
using CaseManagement.Models.Reports;

namespace CaseManagement.Repository.Repositories
{
    public class AlertRulesRepository:IAlertRules
    {
        private readonly AppConnectionString appConnectionString;
        public AlertRulesRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public AlertRuleDTODetailResponse Detail(int rulesId, string userName)
        {
            AlertRuleDTODetailResponse alertRuleDTODetailResponse = new AlertRuleDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.Rules_GetByCode_Admin", new { RulesId = rulesId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    alertRuleDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (alertRuleDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    alertRuleDTODetailResponse.alertRulesDTODetail = result.Read<AlertRulesDTODetail>().FirstOrDefault();
                }
            }
            return alertRuleDTODetailResponse;
        }

        public AlertRuleDTOResponse List(string userName)
        {
            AlertRuleDTOResponse alertRuleDTOResponse = new AlertRuleDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.Rules_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    alertRuleDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (alertRuleDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        alertRuleDTOResponse.alertRules = result.Read<AlertRuleDTO>().ToList();
                    }
                }
            }
            return alertRuleDTOResponse;
        }
    }
}
