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
    public class SurvivorGrantRepository : ISurvivorGrant
    {
        private readonly AppConnectionString appConnectionString;

        public SurvivorGrantRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public SurvivorGrantResponse List(int survivorCode, string userName)
        {
            SurvivorGrantResponse survivorGrantResponse = new SurvivorGrantResponse(); 
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Grant_List_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorGrantResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorGrantResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorGrantResponse.survivorGrantDTOs = result.Read<SurvivorGrantDTO>().ToList();
                    }
                }
            }
            return survivorGrantResponse;
        }

        public SurvivorGrantDTOAddEditResult Add(SurvivorGrantDTOAddDB survivorGrantDTOAddDB)
        {
            SurvivorGrantDTOAddEditResult survivorGrantDTOAddEditResult = new SurvivorGrantDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Grant_Insert_Admin", survivorGrantDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorGrantDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorGrantDTOAddEditResult.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorGrantDTOAddEditResult.SurvivorGrantDTODetail = result.Read<SurvivorGrantDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorGrantDTOAddEditResult;
        }
        public SurvivorGrantDTOAddEditResult Edit(SurvivorGrantDTOEditDB survivorGrantDTOEditDB)
        {
            SurvivorGrantDTOAddEditResult survivorGrantDTOAddEditResult = new SurvivorGrantDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Grant_Update_Admin", survivorGrantDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorGrantDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorGrantDTOAddEditResult.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorGrantDTOAddEditResult.SurvivorGrantDTODetail = result.Read<SurvivorGrantDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorGrantDTOAddEditResult;
        }
        public SurvivorGrantDTOAddEditResult orderEdit(SurvivorGrantOrderEditDB survivorGrantOrderEditDB)
        {
            SurvivorGrantDTOAddEditResult survivorGrantDTOAddEditResult = new SurvivorGrantDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Grant_Order_Update_Admin", survivorGrantOrderEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorGrantDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorGrantDTOAddEditResult.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        survivorGrantDTOAddEditResult.SurvivorGrantDTODetail = result.Read<SurvivorGrantDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorGrantDTOAddEditResult;
        }
        public SurvivorGrantDetailResponse Detail(int grantCode, string userName)
        {
            SurvivorGrantDetailResponse survivorGrantDetailResponse = new SurvivorGrantDetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FinancialInclusion_GetByCode_Admin", new { GrantCode = grantCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorGrantDetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorGrantDetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorGrantDetailResponse.survivorGrantDTODetail = result.Read<SurvivorGrantDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorGrantDetailResponse;
        }
        public SurvivorGrantChangeLogResponse ChangeLog_GetById(int grantCode, string userName)
        {
            SurvivorGrantChangeLogResponse survivorGrantChangeLogResponse = new SurvivorGrantChangeLogResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("GrantLog_GetByCode_Admin", new { GrantCode = grantCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorGrantChangeLogResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorGrantChangeLogResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorGrantChangeLogResponse.survivorGrantChangeLogDTOs = result.Read<SurvivorGrantChangeLogDTO>().ToList();
                    }
                }
            }
            return survivorGrantChangeLogResponse;
        }

        public DataUpdateResponseDTO Delete(int grantCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Grant_Delete_Admin", new { GrantCode = grantCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public SurvivorGrantResponse DeletedList(int survivorCode, string userName)
        {
            SurvivorGrantResponse survivorGrantResponse = new SurvivorGrantResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Grant_Deleted_List_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorGrantResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorGrantResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorGrantResponse.survivorGrantDTOs = result.Read<SurvivorGrantDTO>().ToList();
                    }
                }
            }
            return survivorGrantResponse;
        }

      

    }
}
