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
    public class PoliceStationRepository : IPoliceStation
    {
        private readonly AppConnectionString appConnectionString;
        public PoliceStationRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public PoliceStationDTOResponse List(string userName)
        {
            PoliceStationDTOResponse policeStationDTOResponse = new PoliceStationDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PoliceStation_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    policeStationDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (policeStationDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    policeStationDTOResponse.PoliceStationDTOList = result.Read<PoliceStationDTOList>().ToList();
                }
            }
            return policeStationDTOResponse;
        }
        public PoliceStationDTOAddEditResult Add(PoliceStationDTOAddDB policeStationDTOAddDB)
        {
            PoliceStationDTOAddEditResult policeStationDTOAddEditResult = new PoliceStationDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PoliceStation_Insert_Admin", policeStationDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    policeStationDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (policeStationDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    policeStationDTOAddEditResult.PoliceStationDTODetail = result.Read<PoliceStationDTODetail>().FirstOrDefault();
                }
            }
            return policeStationDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int policeStationCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("PoliceStation_Delete_Admin", new { PoliceStationCode = policeStationCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
        public PoliceStationDTOAddEditResult Edit(PoliceStationDTOEditDB policeStationDTOEditDB)
        {
            PoliceStationDTOAddEditResult policeStationDTOAddEditResult = new PoliceStationDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PoliceStation_Update_Admin", policeStationDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    policeStationDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (policeStationDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    policeStationDTOAddEditResult.PoliceStationDTODetail = result.Read<PoliceStationDTODetail>().FirstOrDefault();
                }
            }
            return policeStationDTOAddEditResult;
        }
        public PoliceStationDTODetailResponse Detail(int policeStationCode, string userName)
        {
            PoliceStationDTODetailResponse policeStationDTODetailResponse = new PoliceStationDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PoliceStation_GetByCode_Admin", new { PoliceStationCode = policeStationCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    policeStationDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (policeStationDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    policeStationDTODetailResponse.PoliceStationDTODetail = result.Read<PoliceStationDTODetail>().FirstOrDefault();
                }
            }
            return policeStationDTODetailResponse;
        }
        public PoliceStationChangeLogDTOResponse ChangeLog_GetById(int policeStationCode, string userName)
        {
            PoliceStationChangeLogDTOResponse policeStationChangeLogDTOResponse = new PoliceStationChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PoliceStationLog_GetByCode_Admin", new { PoliceStationCode = policeStationCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    policeStationChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (policeStationChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    policeStationChangeLogDTOResponse.PoliceStationChangeLogDTOList = result.Read<PoliceStationChangeLogDTOList>().ToList();
                }
            }
            return policeStationChangeLogDTOResponse;
        }
        public PoliceStationDTOResponse DeletedList(string userName)
        {
            PoliceStationDTOResponse policeStationDTOResponse = new PoliceStationDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("PoliceStation_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    policeStationDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (policeStationDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    policeStationDTOResponse.PoliceStationDTOList = result.Read<PoliceStationDTOList>().ToList();
                }
            }
            return policeStationDTOResponse;
        }
    }

}
