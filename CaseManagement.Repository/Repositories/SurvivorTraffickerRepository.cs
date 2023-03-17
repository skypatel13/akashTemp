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
    public class SurvivorTraffickerRepository : ISurvivorTrafficker
    {
        private readonly AppConnectionString appConnectionString;
        public SurvivorTraffickerRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public SurvivorTraffickerDTOResponse List(string userName,int? survivorCode)
        {
            SurvivorTraffickerDTOResponse survivorTraffickerDTOResponse = new SurvivorTraffickerDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_Trafficker_List_Admin", new { UserName = userName , SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorTraffickerDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorTraffickerDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    survivorTraffickerDTOResponse.SurvivorTraffickerDTOList = result.Read<SurvivorTraffickerDTOList>().ToList();
                }
            }
            return survivorTraffickerDTOResponse;
        }
        public DataUpdateResponseDTO Add(SurvivorTraffickerDTOAddDB survivorTraffickerDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Survivor_Trafficker_Insert_Admin", survivorTraffickerDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO AddRelation(SurvivorTraffickerRelationDTOAddDB survivorTraffickerRelationDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("TraffickerRelation_Insert_Admin", survivorTraffickerRelationDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO DeleteRelation(int traffickerRelationCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("TraffickerRelation_Delete_Admin", new { TraffickerRelationCode = traffickerRelationCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SurvivorTraffickerChangeLogDTOResponse ChangeLog_GetById(int survivorCode, string userName)
        {
            SurvivorTraffickerChangeLogDTOResponse survivorTraffickerChangeLogDTOResponse = new SurvivorTraffickerChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Survivor_TraffickerLog_GetByCode_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorTraffickerChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorTraffickerChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    survivorTraffickerChangeLogDTOResponse.SurvivorTraffickerChangeLogDTOList = result.Read<SurvivorTraffickerChangeLogDTOList>().ToList();
                }
            }
            return survivorTraffickerChangeLogDTOResponse;
        }
    }
}
