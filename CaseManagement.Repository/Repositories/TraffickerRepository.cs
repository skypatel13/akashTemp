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
    public class TraffickerRepository : ITrafficker
    {
        private readonly AppConnectionString appConnectionString;
        public TraffickerRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public TraffickerDTOResponse List(string userName)
        {
            TraffickerDTOResponse traffickerDTOResponse = new TraffickerDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Trafficker_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    traffickerDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (traffickerDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        traffickerDTOResponse.TraffickerDTOList = result.Read<TraffickerDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        traffickerDTOResponse.TraffickerStatusLogs = result.Read<TraffickerStatusLog>().ToList();
                    }
                }
            }
            return traffickerDTOResponse;
        }
        public TraffickerDTOAddEditResult Add(TraffickerDTOAddDB traffickerDTOAddDB)
        {
            TraffickerDTOAddEditResult traffickerDTOAddEditResult = new TraffickerDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Trafficker_Insert_Admin", traffickerDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    traffickerDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (traffickerDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        traffickerDTOAddEditResult.TraffickerDTODetail = result.Read<TraffickerDTODetail>().FirstOrDefault();
                    }
                }
            }
            return traffickerDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int traffickerCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Trafficker_Delete_Admin", new { TraffickerCode = traffickerCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public TraffickerDTOAddEditResult Edit(TraffickerDTOEditDB traffickerDTOEditDB)
        {
            TraffickerDTOAddEditResult traffickerDTOAddEditResult = new TraffickerDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Trafficker_Update_Admin", traffickerDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    traffickerDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (traffickerDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        traffickerDTOAddEditResult.TraffickerDTODetail = result.Read<TraffickerDTODetail>().FirstOrDefault();
                    }
                }
            }
            return traffickerDTOAddEditResult;
        }
        public TraffickerDTODetailResponse Detail(int traffickerCode, string userName)
        {
            TraffickerDTODetailResponse traffickerDTODetailResponse = new TraffickerDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Trafficker_GetByCode_Admin", new { TraffickerCode = traffickerCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    traffickerDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (traffickerDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        traffickerDTODetailResponse.TraffickerDTODetail = result.Read<TraffickerDTODetail>().FirstOrDefault();
                    }
                }
            }
            return traffickerDTODetailResponse;
        }
        public TraffickerChangeLogDTOResponse ChangeLog_GetById(int traffickerCode, string userName)
        {
            TraffickerChangeLogDTOResponse traffickerChangeLogDTOResponse = new TraffickerChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("TraffickerLog_GetByCode_Admin", new { TraffickerCode = traffickerCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    traffickerChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (traffickerChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        traffickerChangeLogDTOResponse.TraffickerChangeLogDTOList = result.Read<TraffickerChangeLogDTOList>().ToList();
                    }
                }
            }
            return traffickerChangeLogDTOResponse;
        }
        public TraffickerDTOResponse DeletedList(string userName)
        {
            TraffickerDTOResponse traffickerDTOResponse = new TraffickerDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Trafficker_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    traffickerDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (traffickerDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        traffickerDTOResponse.TraffickerDTOList = result.Read<TraffickerDTOList>().ToList();
                    }
                }
            }
            return traffickerDTOResponse;
        }
        public FirTraffickerResponse firTraffickerResponse(string traffickerId, string userName)
        {
            FirTraffickerResponse firTraffickerResponse = new FirTraffickerResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("FIR_ListByTraffickerId_Admin", new { TraffickerId = traffickerId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    firTraffickerResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (firTraffickerResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    firTraffickerResponse.survivorTraffickerHeaders = result.Read<SurvivorTraffickerHeader>().FirstOrDefault();
                }
                if (firTraffickerResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    firTraffickerResponse.firByTraffickerIdList = result.Read<FirByTraffickerIdDTO>().ToList();
                }
            }
            return firTraffickerResponse;
        }
        public SurvivorTraffickerResponse survivorTraffickerResponse(string traffickerId, string userName)
        {
            SurvivorTraffickerResponse survivorTraffickerResponse = new SurvivorTraffickerResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_ListByTraffickerId_Admin", new { TraffickerId = traffickerId, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorTraffickerResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorTraffickerResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    survivorTraffickerResponse.survivorTraffickerHeaders = result.Read<SurvivorTraffickerHeader>().FirstOrDefault();
                }
                if (survivorTraffickerResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    survivorTraffickerResponse.survivorListByTraffickerId = result.Read<SurvivorListByTraffickerIdDTO>().ToList();
                }
            }
            return survivorTraffickerResponse;
        }
        public TraffickerStatusResponse traffickerStatusResponse(TraffickerStatusDTOAddDB traffickerStatusDTOAddDB)
        {
            TraffickerStatusResponse traffickerStatusResponse = new TraffickerStatusResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("TraffickerStatusLog_Insert_Admin", traffickerStatusDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    traffickerStatusResponse.dataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (traffickerStatusResponse.dataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        traffickerStatusResponse.traffickerDTODetail = result.Read<TraffickerDTODetail>().FirstOrDefault();
                    }
                }
            }
            return traffickerStatusResponse;
        }
        public DataUpdateResponseDTO traffickerStatusDelete(int traffickerStatusLogCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("TraffickerStatusLog_Delete_Admin", new { TraffickerStatusLogCode = traffickerStatusLogCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
