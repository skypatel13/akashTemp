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
    public class DistrictRepository : IDistrict
    {
        private readonly AppConnectionString appConnectionString;

        public DistrictRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public DistrictDTOResponse List(string userName)
        {
            DistrictDTOResponse districtDTOResponse = new DistrictDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("District_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    districtDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (districtDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        districtDTOResponse.DistrictDTOList = result.Read<DistrictDTOList>().ToList();
                    }
                }
            }
            return districtDTOResponse;
        }

        public DataUpdateResponseDTO Add(DistrictDTOAddDB districtDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("District_Insert_Admin", districtDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO Edit(DistrictDTOEditDB districtDTOEditDB )
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("District_Update_Admin", districtDTOEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO Delete(int districtCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("District_Delete_Admin", new { DistrictCode = districtCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DistrictDTOResponse DeletedList(string userName)
        {
            DistrictDTOResponse districtDTOResponse = new DistrictDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("District_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    districtDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (districtDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        districtDTOResponse.DistrictDTOList = result.Read<DistrictDTOList>().ToList();
                    }
                }
            }
            return districtDTOResponse;
        }

        public DistrictDTODetailResponse Detail(int districtCode, string userName)
        {
            DistrictDTODetailResponse districtDTODetailResponse = new DistrictDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("District_GetByCode_Admin", new { DistrictCode = districtCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    districtDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (districtDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        districtDTODetailResponse.DistrictDTODetail = result.Read<DistrictDTODetail>().FirstOrDefault();
                    }
                }
            }
            return districtDTODetailResponse;
        }
        public DistrictChangeLogDTOResponse ChangeLog_GetById(int districtCode, string userName)
        {
            DistrictChangeLogDTOResponse districtChangeLogDTOResponse = new DistrictChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("DistrictLog_GetByCode_Admin", new { DistrictCode = districtCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    districtChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (districtChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        districtChangeLogDTOResponse.DistrictChangeLogDTO = result.Read<DistrictChangeLogDTO>().ToList();
                    }
                }
            }
            return districtChangeLogDTOResponse;
        }
    }
}