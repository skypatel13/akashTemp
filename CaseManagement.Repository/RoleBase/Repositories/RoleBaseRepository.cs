using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Models.RoleBase;
using CaseManagement.Repository.RoleBase.Interfaces;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace CaseManagement.Repository.RoleBase.Repositories
{
    public class RoleBaseRepository : IRoleBase
    {
        private readonly AppConnectionString appConnectionString;

        public RoleBaseRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public RoleBaseMenuDTO RoleBasedMenu_GetByUserName(string userName)
        {
            RoleBaseMenuDTO roleBaseMenuDTO = new RoleBaseMenuDTO();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("RoleBasedMenu_GetByUserName", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    roleBaseMenuDTO.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (roleBaseMenuDTO.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        roleBaseMenuDTO.roleBaseFeatureDTO = result.Read<RoleBaseFeatureDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        roleBaseMenuDTO.roleBaseActionDTO = result.Read<RoleBaseActionDTO>().ToList();
                    }
                }
            }
            return roleBaseMenuDTO;
        }
        public RoleBaseFeaturesAdminDTO Features_GetByRole_Admin(string roleId, string userName)
        {
            RoleBaseFeaturesAdminDTO roleBaseFeaturesAdminDTO = new RoleBaseFeaturesAdminDTO();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Features_GetByRole_Admin", new { RoleId = roleId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    roleBaseFeaturesAdminDTO.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (roleBaseFeaturesAdminDTO.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        roleBaseFeaturesAdminDTO.RoleBaseDTOHeader = result.Read<RoleBaseDTOHeader>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        roleBaseFeaturesAdminDTO.roleBaseFeatureAdminDTO = result.Read<RoleBaseFeatureAdminDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        roleBaseFeaturesAdminDTO.roleBaseActionAdminDTO = result.Read<RoleBaseActionAdminDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        roleBaseFeaturesAdminDTO.roleBaseFeatureActionFMap = result.Read<RoleBaseFeatureActionFMap>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        roleBaseFeaturesAdminDTO.roleBaseFeatureActionFAMap = result.Read<RoleBaseFeatureActionFAMap>().ToList();
                    }
                }
            }
            return roleBaseFeaturesAdminDTO;
        }
        public DataUpdateResponseDTO Features_Insert_ByRole_Admin(RoleBaseFeaturesDTOInsertDB roleBaseFeaturesDTOInsertDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Features_Insert_ByRole_Admin", roleBaseFeaturesDTOInsertDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
