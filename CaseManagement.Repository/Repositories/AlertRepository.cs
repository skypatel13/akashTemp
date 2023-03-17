using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Models.Reports;
using CaseManagement.Repository.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CaseManagement.Repository.Repositories
{
    public class AlertRepository : IAlert
    {
        private readonly AppConnectionString appConnectionString;

        public AlertRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public AlertDTOResponse List(string userName)
        {
            AlertDTOResponse alertDTOListResponse = new AlertDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.Messages_GetByUserName", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    alertDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (alertDTOListResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        alertDTOListResponse.AlertDTOList = result.Read<AlertDTOList>().ToList();
                    }
                }
            }
            return alertDTOListResponse;
        }

        public AlertSummaryDTOResponse SummaryList(string userName)
        {
            AlertSummaryDTOResponse alertSummaryDTOResponse = new AlertSummaryDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.Summary_GetByUserName", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    alertSummaryDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (alertSummaryDTOResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        alertSummaryDTOResponse.AlertSummaryDTOList = result.Read<AlertSummaryDTOList>().ToList();
                    }
                }
            }
            return alertSummaryDTOResponse;
        }

        public AlertDTOAddEditResult MessageReadUpdate(int messageId, string modifiedBy, string modifiedByIpAddress)
        {
            AlertDTOAddEditResult alertDTOAddEditResult = new AlertDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.MessageRead_Update_Admin", new { MessageId = messageId, ModifiedBy = modifiedBy, ModifiedByIpAddress = modifiedByIpAddress }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    alertDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (alertDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    alertDTOAddEditResult.AlertDTODetail = result.Read<AlertDTODetail>().FirstOrDefault();
                }
            }
            return alertDTOAddEditResult;
        }

        public AlertDTODetailResponse Detail(int messageId, string userName)
        {
            AlertDTODetailResponse alertDTODetailResponse = new AlertDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.Message_GetByCode_Admin", new { MessageId = messageId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    alertDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (alertDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    alertDTODetailResponse.AlertDTODetail = result.Read<AlertDTODetail>().FirstOrDefault();
                }
            }
            return alertDTODetailResponse;
        }
        public EmailDTODetailResponse EmailAdd(EmailDTOAdd emailDTOAdd)
        {
            EmailDTODetailResponse emailDTODetailResponse = new EmailDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Alert.Email_Insert_Admin", emailDTOAdd, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    emailDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (emailDTODetailResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        emailDTODetailResponse.EmailDTODetail = result.Read<EmailDTODetail>().FirstOrDefault();
                    }
                }
            }
            return emailDTODetailResponse;
        }

        public DataUpdateResponseDTO EmailUpdateIsReceived(EmailUpdateResponseDTO emailUpdateResponseDTO)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("Alert.Email_Update_IsReceived_Admin", emailUpdateResponseDTO, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}