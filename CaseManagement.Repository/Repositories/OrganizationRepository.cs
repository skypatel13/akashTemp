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
    public class OrganizationRepository : IOrganization
    {
        private readonly AppConnectionString appConnectionString;

        public OrganizationRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public OrganizationDTOResponse List(string userName)
        {
            OrganizationDTOResponse organizationDTOResponse = new OrganizationDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Organization_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    organizationDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (organizationDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        organizationDTOResponse.OrganizationDTOList = result.Read<OrganizationDTOList>().ToList();
                    }
                }
            }
            return organizationDTOResponse;
        }

        public OrganizationDTOResponse Deleted_List(string userName)
        {
            OrganizationDTOResponse organizationDTOResponse = new OrganizationDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Organization_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    organizationDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (organizationDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        organizationDTOResponse.OrganizationDTOList = result.Read<OrganizationDTOList>().ToList();
                    }
                }
            }
            return organizationDTOResponse;
        }

        public DataUpdateResponseDTO Add(OrganizationDTOAddDB organizationDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Organization_Insert_Admin", organizationDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO Delete(int organizationId, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Organization_Delete_Admin", new { OrganizationId = organizationId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO Edit(OrganizationDTOEditDB organizationDTOEditDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Organization_Update_Admin", organizationDTOEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public OrganizationDTODetailResponse Detail(int organizationId, string userName)
        {
            OrganizationDTODetailResponse organizationDTODetailResponse = new OrganizationDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Organization_GetById_Admin", new { OrganizationId = organizationId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    organizationDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (organizationDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        organizationDTODetailResponse.OrganizationDTODetail = result.Read<OrganizationDTODetail>().FirstOrDefault();
                    }
                }
            }
            return organizationDTODetailResponse;
        }

        public OrganizationChangeLogDTOResponse ChangeLog_GetById(int organizationId, string userName)
        {
            OrganizationChangeLogDTOResponse organizationChangeLogDTOResponse = new OrganizationChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("OrganizationLog_GetById_Admin", new { OrganizationId = organizationId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    organizationChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (organizationChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        organizationChangeLogDTOResponse.OrganizationChangeLogDTOList = result.Read<OrganizationChangeLogDTOList>().ToList();
                    }
                }
            }
            return organizationChangeLogDTOResponse;
        }
    }
}