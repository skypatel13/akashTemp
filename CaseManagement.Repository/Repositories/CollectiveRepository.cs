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
    public class CollectiveRepository : ICollective
    {
        private readonly AppConnectionString appConnectionString;

        public CollectiveRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public CollectiveDTOResponse List(string userName)
        {
            CollectiveDTOResponse collectiveDTOResponse = new CollectiveDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Collective_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    collectiveDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (collectiveDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        collectiveDTOResponse.CollectiveDTOList = result.Read<CollectiveDTOList>().ToList();
                    }
                }
            }
            return collectiveDTOResponse;
        }

        public DataUpdateResponseDTO Add(CollectiveDTOAddDB collectiveDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Collective_Insert_Admin", collectiveDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO Edit(CollectiveDTOEditDB collectiveDTOEditDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Collective_Update_Admin", collectiveDTOEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO Delete(int collectiveCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Collective_Delete_Admin", new { CollectiveCode = collectiveCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public CollectiveDTOResponse DeletedList(string userName)
        {
            CollectiveDTOResponse collectiveDTOResponse = new CollectiveDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Collective_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    collectiveDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (collectiveDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        collectiveDTOResponse.CollectiveDTOList = result.Read<CollectiveDTOList>().ToList();
                    }
                }
            }
            return collectiveDTOResponse;
        }

        public CollectiveDTODetailResponse Detail(int collectiveCode, string userName)
        {
            CollectiveDTODetailResponse collectiveDTODetailResponse = new CollectiveDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Collective_GetById_Admin", new { CollectiveCode = collectiveCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    collectiveDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (collectiveDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        collectiveDTODetailResponse.CollectiveDTODetail = result.Read<CollectiveDTODetail>().FirstOrDefault();
                    }
                }
            }
            return collectiveDTODetailResponse;
        }

        public CollectiveChangeLogDTOResponse ChangeLog_GetById(int collectiveCode, string userName)
        {
            CollectiveChangeLogDTOResponse collectiveChangeLogDTOResponse = new CollectiveChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CollectiveLog_GetByCode_Admin", new { CollectiveCode = collectiveCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    collectiveChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (collectiveChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        collectiveChangeLogDTOResponse.CollectiveChangeLogDTOList = result.Read<CollectiveChangeLogDTOList>().ToList();
                    }
                }
            }
            return collectiveChangeLogDTOResponse;
        }
    }
}