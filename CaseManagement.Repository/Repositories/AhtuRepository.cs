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
    public class AhtuRepository : IAhtu
    {
        private readonly AppConnectionString appConnectionString;
        public AhtuRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public AhtuDTOResponse List(string userName)
        {
            AhtuDTOResponse ahtuDTOResponse = new AhtuDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("AHTU_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    ahtuDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (ahtuDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    ahtuDTOResponse.AhtuDTOList = result.Read<AhtuDTOList>().ToList();
                }
            }
            return ahtuDTOResponse;
        }
        public AhtuDTOAddEditResult Add(AhtuDTOAddDB ahtuDTOAddDB)
        {
            AhtuDTOAddEditResult ahtuDTOAddEditResult = new AhtuDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("AHTU_Insert_Admin", ahtuDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    ahtuDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (ahtuDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    ahtuDTOAddEditResult.AhtuDTODetail = result.Read<AhtuDTODetail>().FirstOrDefault();
                }
            }
            return ahtuDTOAddEditResult;
        }
        public DataUpdateResponseDTO Delete(int ahtuCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("Ahtu_Delete_Admin", new { AhtuCode = ahtuCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
        public AhtuDTOAddEditResult Edit(AhtuDTOEditDB ahtuDTOEditDB)
        {
            AhtuDTOAddEditResult ahtuDTOAddEditResult = new AhtuDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Ahtu_Update_Admin", ahtuDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    ahtuDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (ahtuDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    ahtuDTOAddEditResult.AhtuDTODetail = result.Read<AhtuDTODetail>().FirstOrDefault();
                }
            }
            return ahtuDTOAddEditResult;
        }
        public AhtuDTODetailResponse Detail(int ahtuCode, string userName)
        {
            AhtuDTODetailResponse ahtuDTODetailResponse = new AhtuDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Ahtu_GetByCode_Admin", new { AhtuCode = ahtuCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    ahtuDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (ahtuDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    ahtuDTODetailResponse.AhtuDTODetail = result.Read<AhtuDTODetail>().FirstOrDefault();
                }
            }
            return ahtuDTODetailResponse;
        }
        public AhtuChangeLogDTOResponse ChangeLog_GetById(int ahtuCode, string userName)
        {
            AhtuChangeLogDTOResponse ahtuChangeLogDTOResponse = new AhtuChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("AhtuLog_GetByCode_Admin", new { AhtuCode = ahtuCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    ahtuChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (ahtuChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    ahtuChangeLogDTOResponse.AhtuChangeLogDTOList = result.Read<AhtuChangeLogDTOList>().ToList();
                }
            }
            return ahtuChangeLogDTOResponse;
        }
        public AhtuDTOResponse DeletedList(string userName)
        {
            AhtuDTOResponse ahtuDTOResponse = new AhtuDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Ahtu_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    ahtuDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (ahtuDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    ahtuDTOResponse.AhtuDTOList = result.Read<AhtuDTOList>().ToList();
                }
            }
            return ahtuDTOResponse;
        }
    }
}
