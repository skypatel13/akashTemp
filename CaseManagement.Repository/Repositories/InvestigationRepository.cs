using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CaseManagement.Repository.Repositories
{
    public class InvestigationRepository : IInvestigation
    {
        private readonly AppConnectionString appConnectionString;
        public InvestigationRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public InvestigationDTOResponse List(string userName, int survivorCode)
        {
            InvestigationDTOResponse InvestigationDTOResponse = new InvestigationDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Investigation_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    InvestigationDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (InvestigationDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    InvestigationDTOResponse.InvestigationDTOList = result.Read<InvestigationDTOList>().ToList();
                }
                if (InvestigationDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    InvestigationDTOResponse.InvestigationDetailChangeDTOList = result.Read<InvestigationDetailChangeDTOList>().ToList();
                }
            }
            return InvestigationDTOResponse;
        }

        public InvestigationDTOAddEditResult Add(InvestigationDTOAddDB investigationDTOAddDB)
        {
            InvestigationDTOAddEditResult investigationDTOAddEditResult = new InvestigationDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Investigation_Insert_Admin", investigationDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    investigationDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (investigationDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    investigationDTOAddEditResult.InvestigationDTODetail = result.Read<InvestigationDTODetail>().FirstOrDefault();
                }
            }
            return investigationDTOAddEditResult;
        }

        public DataUpdateResponseDTO Delete(int investigationCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Investigation_Delete_Admin", new { InvestigationCode = investigationCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public InvestigationDTOAddEditResult Edit(InvestigationDTOEditDB investigationDTOEditDB)
        {
            InvestigationDTOAddEditResult InvestigationDTOAddEditResult = new InvestigationDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Investigation_Update_Admin", investigationDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    InvestigationDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (InvestigationDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    InvestigationDTOAddEditResult.InvestigationDTODetail = result.Read<InvestigationDTODetail>().FirstOrDefault();
                }
            }
            return InvestigationDTOAddEditResult;
        }

        public InvestigationDTODetailResponse Detail(int investigationCode, string userName)
        {
            InvestigationDTODetailResponse InvestigationDTODetailResponse = new InvestigationDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Investigation_GetByCode_Admin", new { InvestigationCode = investigationCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    InvestigationDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (InvestigationDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    InvestigationDTODetailResponse.InvestigationDTODetail = result.Read<InvestigationDTODetail>().FirstOrDefault();
                }
            }
            return InvestigationDTODetailResponse;
        }
        public InvestigationChangeLogDTOResponse ChangeLog_GetById(int investigationCode, string userName)
        {
            InvestigationChangeLogDTOResponse investigationChangeLogDTOResponse = new InvestigationChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("InvestigationLog_GetByCode_Admin", new { InvestigationCode = investigationCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    investigationChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (investigationChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    investigationChangeLogDTOResponse.InvestigationChangeLogDTOList = result.Read<InvestigationChangeLogDTOList>().ToList();
                }
                if (investigationChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    investigationChangeLogDTOResponse.InvestigationAgencyChangeLogDTOList = result.Read<InvestigationAgencyChangeLogDTOList>().ToList();
                }
                if (investigationChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    investigationChangeLogDTOResponse.InvestigationStatusChangeLogDTOList = result.Read<InvestigationStatusChangeLogDTOList>().ToList();
                }
            }
            return investigationChangeLogDTOResponse;
        }
        public InvestigationDTOResponse DeletedList(string userName,int survivorCode)
        {
            InvestigationDTOResponse InvestigationDTOResponse = new InvestigationDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Investigation_Deleted_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    InvestigationDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (InvestigationDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    InvestigationDTOResponse.InvestigationDTOList = result.Read<InvestigationDTOList>().ToList();
                }
            }
            return InvestigationDTOResponse;
        }
        public InvestigationDTOAddEditResult OfficerChange(InvestigationOfficerChangeDTOAddDB investigationOfficerChangeDTOAddDB)
        {
            InvestigationDTOAddEditResult investigationDTOAddEditResult = new InvestigationDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Investigation_ChangeOfficer_Admin", investigationOfficerChangeDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    investigationDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (investigationDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    investigationDTOAddEditResult.InvestigationDTODetail = result.Read<InvestigationDTODetail>().FirstOrDefault();
                }
            }
            return investigationDTOAddEditResult;
        }
        public InvestigationDTOAddEditResult AgencyChange(InvestigationAgencyChangeDTOAddDB investigationAgencyChangeDTOAddDB)
        {
            InvestigationDTOAddEditResult investigationDTOAddEditResult = new InvestigationDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Investigation_Transfer_Agency_Admin", investigationAgencyChangeDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    investigationDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (investigationDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    investigationDTOAddEditResult.InvestigationDTODetail = result.Read<InvestigationDTODetail>().FirstOrDefault();
                }
            }
            return investigationDTOAddEditResult;
        }
        public InvestigationDTOAddEditResult StatusChange(InvestigationStatusChangeDTOAddDB investigationStatusChangeDTOAddDB)
        {
            InvestigationDTOAddEditResult InvestigationDTOAddEditResult = new InvestigationDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Investigation_ChangeStatus_Admin", investigationStatusChangeDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    InvestigationDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (InvestigationDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    InvestigationDTOAddEditResult.InvestigationDTODetail = result.Read<InvestigationDTODetail>().FirstOrDefault();
                }
            }
            return InvestigationDTOAddEditResult;
        }
        public InvestigationDTOAddEditResult Acceptance(InvestigationAcceptanceDTOUpdateDB investigationAcceptanceDTOUpdateDB)
        {
            InvestigationDTOAddEditResult InvestigationDTOAddEditResult = new InvestigationDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Investigation_Acceptance_Update_Admin", investigationAcceptanceDTOUpdateDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    InvestigationDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (InvestigationDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    InvestigationDTOAddEditResult.InvestigationDTODetail = result.Read<InvestigationDTODetail>().FirstOrDefault();
                }
            }
            return InvestigationDTOAddEditResult;
        }
    }
}
