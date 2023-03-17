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
    public class ActRepository : IAct
    {
        private readonly AppConnectionString appConnectionString;
        public ActRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public ActDTOResponse List(string userName)
        {
            ActDTOResponse actDTOListResponse = new ActDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Act_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    actDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (actDTOListResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        actDTOListResponse.ActDTOList = result.Read<ActDTOList>().ToList();
                    }
                }
            }
            return actDTOListResponse;
        }
        public ActDTOAddEditResult Add(ActDTOAddDB actDTOAddDB)
        {
            ActDTOAddEditResult actDTOAddEditResult = new ActDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Act_Insert_Admin", actDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    actDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (actDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        actDTOAddEditResult.ActDTODetail = result.Read<ActDTODetail>().FirstOrDefault();
                    }
                }
            }
            return actDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int actCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Act_Delete_Admin", new { ActCode = actCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public ActDTOAddEditResult Edit(ActDTOEditDB actDTOEditDB)
        {
            ActDTOAddEditResult actDTOAddEditResult = new ActDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Act_Update_Admin", actDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    actDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (actDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        actDTOAddEditResult.ActDTODetail = result.Read<ActDTODetail>().FirstOrDefault();
                    }
                }
            }
            return actDTOAddEditResult;
        }
        public ActDetailResponse Detail(int actCode, string userName)
        {
            ActDetailResponse actDetailResponse = new ActDetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Act_GetByCode_Admin", new { ActCode = actCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    actDetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (actDetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        actDetailResponse.ActDetail = result.Read<ActDTODetail>().FirstOrDefault();
                    }
                }
            }
            return actDetailResponse;
        }
        public ActChangeLogDTOResponse ChangeLog_GetById(int actCode, string userName)
        {
            ActChangeLogDTOResponse actChangeLogDTOResponse = new ActChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ActLog_GetByCode_Admin", new { ActCode = actCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    actChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (actChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        actChangeLogDTOResponse.ActChangeLogDTOList = result.Read<ActChangeLogDTOList>().ToList();
                    }
                }
            }
            return actChangeLogDTOResponse;
        }
        public ActDTOResponse DeletedList(string userName)
        {
            ActDTOResponse actDTOListResponse = new ActDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Act_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    actDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (actDTOListResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        actDTOListResponse.ActDTOList = result.Read<ActDTOList>().ToList();
                    }
                }
            }
            return actDTOListResponse;
        }
    }
}
