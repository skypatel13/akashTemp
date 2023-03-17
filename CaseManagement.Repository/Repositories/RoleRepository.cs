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
    public class RoleRepository : IRole
    {
        private readonly AppConnectionString appConnectionString;

        public RoleRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public DataUpdateResponseDTO Add(RoleDTOAddDB roleDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Role_Insert_Admin", roleDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO Edit(RoleDTOEditDB roleDTOEditDB )
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Role_Update_Admin", roleDTOEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public RoleDTOResponse List(string userName)
        {
            RoleDTOResponse roleDTOResponse = new RoleDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Role_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    roleDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (roleDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        roleDTOResponse.RoleDTOList = result.Read<RoleDTOList>().ToList();
                    }
                }
            }
            return roleDTOResponse;
        }
        public DataUpdateResponseDTO Delete(string roleId, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Role_Delete_Admin", new { RoleId = roleId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public RoleDTOResponse DeletedList(string userName)
        {
            RoleDTOResponse roleDTOResponse = new RoleDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Role_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    roleDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (roleDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        roleDTOResponse.RoleDTOList = result.Read<RoleDTOList>().ToList();
                    }
                }
            }
            return roleDTOResponse;
        }
        public RoleChangeLogDTOResponse ChangeLog_GetById(string roleId, string userName)
        {
            RoleChangeLogDTOResponse roleChangeLogDTOResponse = new RoleChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("RoleLog_GetById_Admin", new { RoleId = roleId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    roleChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (roleChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        roleChangeLogDTOResponse.RoleChangeLogDTOList = result.Read<RoleChangeLogDTOList>().ToList();
                    }
                }
            }
            return roleChangeLogDTOResponse;
        }
        public RoleDTODetailResponse Detail(string roleId,string userName)
        {
            RoleDTODetailResponse roleDTODetailResponse = new RoleDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Role_GetById_Admin", new { RoleId= roleId ,UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    roleDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (roleDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        roleDTODetailResponse.RoleDTODetail = result.Read<RoleDTODetail>().FirstOrDefault();
                    }
                }
            }
            return roleDTODetailResponse;
        }
    }
}