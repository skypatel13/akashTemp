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
    public class RescueRepository : IRescue
    {
        private readonly AppConnectionString appConnectionString;
        public RescueRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public RescueDTOResponse List(string userName, int? survivorCode = 0)
        {
            RescueDTOResponse rescueDTOResponse = new RescueDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Rescue_List_Admin", new { UserName = userName, SurvivorCode = survivorCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    rescueDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (rescueDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        rescueDTOResponse.RescueDTOList = result.Read<RescueDTOList>().ToList();
                    }
                }
            }
            return rescueDTOResponse;
        }
        public RescueDTOAddEditResult Add(RescueDTOAddDB rescueDTOAddDB)
        {
            RescueDTOAddEditResult rescueDTOAddEditResult = new RescueDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Rescue_Insert_Admin", rescueDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    rescueDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (rescueDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        rescueDTOAddEditResult.RescueDTODetail = result.Read<RescueDTODetail>().FirstOrDefault();
                    }
                }
            }
            return rescueDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int rescueCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Rescue_Delete_Admin", new { RescueCode = rescueCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public RescueDTOAddEditResult Edit(RescueDTOEditDB rescueDTOEditDB)
        {
            RescueDTOAddEditResult rescueDTOAddEditResult = new RescueDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Rescue_Update_Admin", rescueDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    rescueDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (rescueDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        rescueDTOAddEditResult.RescueDTODetail = result.Read<RescueDTODetail>().FirstOrDefault();
                    }
                }
            }
            return rescueDTOAddEditResult;
        }
        public RescueDTODetailResponse Detail(int rescueCode, string userName)
        {
            RescueDTODetailResponse rescueDTODetailResponse = new RescueDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Rescue_GetByCode_Admin", new { RescueCode = rescueCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    rescueDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (rescueDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        rescueDTODetailResponse.RescueDTODetail = result.Read<RescueDTODetail>().FirstOrDefault();
                    }
                }
            }
            return rescueDTODetailResponse;
        }
        public RescueChangeLogDTOResponse ChangeLog_GetById(int rescueCode, string userName)
        {
            RescueChangeLogDTOResponse rescueChangeLogDTOResponse = new RescueChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("RescueLog_GetByCode_Admin", new { RescueCode = rescueCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    rescueChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (rescueChangeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        rescueChangeLogDTOResponse.RescueChangeLogDTOList = result.Read<RescueChangeLogDTOList>().ToList();
                    }
                }
            }
            return rescueChangeLogDTOResponse;
        }
        public RescueDTOResponse DeletedList(string userName)
        {
            RescueDTOResponse rescueDTOResponse = new RescueDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Rescue_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    rescueDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (rescueDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        rescueDTOResponse.RescueDTOList = result.Read<RescueDTOList>().ToList();
                    }
                }
            }
            return rescueDTOResponse;
        }
    }
}
