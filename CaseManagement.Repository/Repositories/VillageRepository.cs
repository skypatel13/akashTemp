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
    public class VillageRepository : IVillage
    {
        private readonly AppConnectionString appConnectionString;
        public VillageRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public VillageDTOResponse List(string userName)
        {
            VillageDTOResponse villageDTOListResponse = new VillageDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Village_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    villageDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (villageDTOListResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        villageDTOListResponse.VillageDTOList = result.Read<VillageDTOList>().ToList();
                    }
                }
            }
            return villageDTOListResponse;
        }

        public VillageDTOAddEditResult Add(VillageDTOAddDB villageDTOAddDB)
        {
            VillageDTOAddEditResult villageDTOAddEditResult = new VillageDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Village_Insert_Admin", villageDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    villageDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (villageDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        villageDTOAddEditResult.VillageDTODetail = result.Read<VillageDTODetail>().FirstOrDefault();
                    }
                }
            }
            return villageDTOAddEditResult;
        }
        public VillageDTOAddEditResult Edit(VillageDTOEditDB villageDTOEditDB)
        {
            VillageDTOAddEditResult villageDTOAddEditResult = new VillageDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Village_Update_Admin", villageDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    villageDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (villageDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    villageDTOAddEditResult.VillageDTODetail = result.Read<VillageDTODetail>().FirstOrDefault();
                }
            }
            return villageDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int villageCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("Village_Delete_Admin", new { VillageCode = villageCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
        public VillageDTODetailResponse Detail(int villageCode, string userName)
        {
            VillageDTODetailResponse villageDTODetailResponse = new VillageDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Village_GetByCode_Admin", new { VillageCode = villageCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    villageDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (villageDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    villageDTODetailResponse.VillageDTODetail = result.Read<VillageDTODetail>().FirstOrDefault();
                }
            }
            return villageDTODetailResponse;
        }
        public VillageDTOResponse DeletedList(string userName)
        {
            VillageDTOResponse villageDTOResponse = new VillageDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Village_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    villageDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (villageDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    villageDTOResponse.VillageDTOList = result.Read<VillageDTOList>().ToList();
                }
            }
            return villageDTOResponse;
        }

        public VillageChangeLogDTOResponse ChangeLog_GetById(int villageCode, string userName)
        {
            VillageChangeLogDTOResponse villageChangeLogDTOResponse = new VillageChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("VillageLog_GetByCode_Admin", new { VillageCode = villageCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    villageChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (villageChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        villageChangeLogDTOResponse.VillageChangeLogDTOList = result.Read<VillageChangeLogDTOList>().ToList();
                    }
                }
            }
            return villageChangeLogDTOResponse;
        }
    }
}
