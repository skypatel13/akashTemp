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
    public class PartnerRepository : IPartner
    {
        private readonly AppConnectionString appConnectionString;

        public PartnerRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public PartnerDTOResponse List(string userName)
        {
            PartnerDTOResponse partnerDTOResponse = new PartnerDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Partner_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    partnerDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (partnerDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        partnerDTOResponse.PartnerDTOList = result.Read<PartnerDTOList>().ToList();
                    }
                }
            }
            return partnerDTOResponse;
        }

        public PartnerDTOResponse Deleted_List(string userName)
        {
            PartnerDTOResponse partnerDTOResponse = new PartnerDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Partner_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    partnerDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (partnerDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        partnerDTOResponse.PartnerDTOList = result.Read<PartnerDTOList>().ToList();
                    }
                }
            }
            return partnerDTOResponse;
        }

        public DataUpdateResponseDTO Add(PartnerDTOAddDB partnerDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Partner_Insert_Admin", partnerDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO Edit(PartnerDTOEditDB partnerDTOEditDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Partner_Update_Admin", partnerDTOEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO Delete(int partnerCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Partner_Delete_Admin", new { PartnerCode = partnerCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public PartnerDTODetailResponse Detail(string userName, int partnerCode)
        {
            PartnerDTODetailResponse partnerDTODetailResponse = new PartnerDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Partner_GetById_Admin", new { UserName = userName, PartnerCode = partnerCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    partnerDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (partnerDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        partnerDTODetailResponse.PartnerDTODetail = result.Read<PartnerDTODetail>().FirstOrDefault();
                    }
                }
            }
            return partnerDTODetailResponse;
        }

        public PartnerChangeLogDTOResponse ChangeLog_GetById(string userName, int partnerCode)
        {
            PartnerChangeLogDTOResponse partnerChangeLogDTOResponse = new PartnerChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PartnerLog_GetById_Admin", new { UserName = userName, PartnerCode = partnerCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    partnerChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (partnerChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        partnerChangeLogDTOResponse.PartnerChangeLogDTOList = result.Read<PartnerChangeLogDTOList>().ToList();
                    }
                }
            }
            return partnerChangeLogDTOResponse;
        }
    }
}