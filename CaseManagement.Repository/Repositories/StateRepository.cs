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
    public class StateRepository : IState
    {
        private readonly AppConnectionString appConnectionString;

        public StateRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public StateDTOResponse List(string userName)
        {
            StateDTOResponse stateDTOResponse = new StateDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("State_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    stateDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (stateDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        stateDTOResponse.StateDTOList = result.Read<StateDTOList>().ToList();
                    }
                }
            }
            return stateDTOResponse;
        }

        public StateDTOResponse Deleted_List(string userName)
        {
            StateDTOResponse stateDTOResponse = new StateDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("State_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    stateDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (stateDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        stateDTOResponse.StateDTOList = result.Read<StateDTOList>().ToList();
                    }
                }
            }
            return stateDTOResponse;
        }

        public DataUpdateResponseDTO Add(StateDTOAddDB stateDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("State_Insert_Admin", stateDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO Delete(int stateCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("State_Delete_Admin", new { StateCode = stateCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public StateDTODetailResponse Detail(int stateCode, string userName)
        {
            StateDTODetailResponse stateDTODetailResponse = new StateDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("State_GetById_Admin", new { StateCode = stateCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    stateDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (stateDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        stateDTODetailResponse.StateDTODetail = result.Read<StateDTODetail>().FirstOrDefault();
                    }
                }
            }
            return stateDTODetailResponse;
        }

        public DataUpdateResponseDTO Edit(StateDTOEditDB stateDTOEditDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("State_Update_Admin", stateDTOEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public StateChangeLogDTOResponse ChangeLog_GetById(int stateCode, string userName)
        {
            StateChangeLogDTOResponse stateChangeLogDTOResponse = new StateChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("StateLog_GetById_Admin", new { StateCode = stateCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    stateChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (stateChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        stateChangeLogDTOResponse.StateChangeLogDTOList = result.Read<StateChangeLogDTOList>().ToList();
                    }
                }
            }
            return stateChangeLogDTOResponse;
        }
    }
}