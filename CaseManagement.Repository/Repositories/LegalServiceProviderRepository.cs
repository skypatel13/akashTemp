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
    public class LegalServiceProviderRepository : ILegalServiceProvider
    {
        private readonly AppConnectionString appConnectionString;
        public LegalServiceProviderRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public LegalServiceProviderDTOResponse List(string userName)
        {
            LegalServiceProviderDTOResponse legalServiceProviderDTOResponse = new LegalServiceProviderDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceProvider_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceProviderDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceProviderDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceProviderDTOResponse.LegalServiceProviderDTOList = result.Read<LegalServiceProviderDTOList>().ToList();
                    }
                }
            }
            return legalServiceProviderDTOResponse;
        }
        public LegalServiceProviderDTOAddEditResult Add(LegalServiceProviderDTOAddDB actDTOAddDB)
        {
            LegalServiceProviderDTOAddEditResult legalServiceProviderDTOAddEditResult = new LegalServiceProviderDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceProvider_Insert_Admin", actDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceProviderDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceProviderDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceProviderDTOAddEditResult.LegalServiceProviderDTODetail = result.Read<LegalServiceProviderDTODetail>().FirstOrDefault();
                    }
                }
            }
            return legalServiceProviderDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int actCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("LegalServiceProvider_Delete_Admin", new { LegalServiceProviderCode = actCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public LegalServiceProviderDTOAddEditResult Edit(LegalServiceProviderDTOEditDB actDTOEditDB)
        {
            LegalServiceProviderDTOAddEditResult legalServiceProviderDTOAddEditResult = new LegalServiceProviderDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceProvider_Update_Admin", actDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceProviderDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceProviderDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceProviderDTOAddEditResult.LegalServiceProviderDTODetail = result.Read<LegalServiceProviderDTODetail>().FirstOrDefault();
                    }
                }
            }
            return legalServiceProviderDTOAddEditResult;
        }
        public LegalServiceProviderDTODetailResponse Detail(int actCode, string userName)
        {
            LegalServiceProviderDTODetailResponse legalServiceProviderDTODetailResponse = new LegalServiceProviderDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceProvider_GetByCode_Admin", new { LegalServiceProviderCode = actCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceProviderDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceProviderDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceProviderDTODetailResponse.LegalServiceProviderDTODetail = result.Read<LegalServiceProviderDTODetail>().FirstOrDefault();
                    }
                }
            }
            return legalServiceProviderDTODetailResponse;
        }
        public LegalServiceProviderChangeLogDTOResponse ChangeLog_GetById(int actCode, string userName)
        {
            LegalServiceProviderChangeLogDTOResponse legalServiceProviderChangeLogDTOResponse = new LegalServiceProviderChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceProviderLog_GetByCode_Admin", new { LegalServiceProviderCode = actCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceProviderChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceProviderChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceProviderChangeLogDTOResponse.LegalServiceProviderChangeLogDTOList = result.Read<LegalServiceProviderChangeLogDTOList>().ToList();
                    }
                }
            }
            return legalServiceProviderChangeLogDTOResponse;
        }
        public LegalServiceProviderDTOResponse DeletedList(string userName)
        {
            LegalServiceProviderDTOResponse legalServiceProviderDTOResponse = new LegalServiceProviderDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LegalServiceProvider_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    legalServiceProviderDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (legalServiceProviderDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        legalServiceProviderDTOResponse.LegalServiceProviderDTOList = result.Read<LegalServiceProviderDTOList>().ToList();
                    }
                }
            }
            return legalServiceProviderDTOResponse;
        }
    }
}
