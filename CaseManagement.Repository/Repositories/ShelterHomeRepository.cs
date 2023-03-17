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
    public class ShelterHomeRepository : IShelterHome
    {
        private readonly AppConnectionString appConnectionString;

        public ShelterHomeRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public ShelterHomeDTOResponse List(string userName)
        {
            ShelterHomeDTOResponse shelterHomeDTOResponse = new ShelterHomeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHome_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeDTOResponse.ShelterHomeDTOList = result.Read<ShelterHomeDTOList>().ToList();
                }
            }
            return shelterHomeDTOResponse;
        }

        public ShelterHomeDTOAddEditResult Add(ShelterHomeDTOAddDB shelterHomeDTOAddDB)
        {
            ShelterHomeDTOAddEditResult shelterHomeDTOAddEditResult = new ShelterHomeDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHome_Insert_Admin", shelterHomeDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeDTOAddEditResult.ShelterHomeDTODetail = result.Read<ShelterHomeDTODetail>().FirstOrDefault();
                }
            }
            return shelterHomeDTOAddEditResult;
        }

        public DataUpdateResponseDTO Delete(int shelterHomeCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("ShelterHome_Delete_Admin", new { ShelterHomeCode = shelterHomeCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public ShelterHomeDTOAddEditResult Edit(ShelterHomeDTOEditDB shelterHomeDTOEditDB)
        {
            ShelterHomeDTOAddEditResult shelterHomeDTOAddEditResult = new ShelterHomeDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHome_Update_Admin", shelterHomeDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeDTOAddEditResult.ShelterHomeDTODetail = result.Read<ShelterHomeDTODetail>().FirstOrDefault();
                }
            }
            return shelterHomeDTOAddEditResult;
        }

        public ShelterHomeDTODetailResponse Detail(int shelterHomeCode, string userName)
        {
            ShelterHomeDTODetailResponse shelterHomeDTODetailResponse = new ShelterHomeDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHome_GetByCode_Admin", new { ShelterHomeCode = shelterHomeCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeDTODetailResponse.ShelterHomeDTODetail = result.Read<ShelterHomeDTODetail>().FirstOrDefault();
                }
            }
            return shelterHomeDTODetailResponse;
        }

        public ShelterHomeChangeLogDTOResponse ChangeLog_GetById(int shelterHomeCode, string userName)
        {
            ShelterHomeChangeLogDTOResponse shelterHomeChangeLogDTOResponse = new ShelterHomeChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHomeLog_GetByCode_Admin", new { ShelterHomeCode = shelterHomeCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeChangeLogDTOResponse.ShelterHomeChangeLogDTOList = result.Read<ShelterHomeChangeLogDTOList>().ToList();
                }
            }
            return shelterHomeChangeLogDTOResponse;
        }

        public ShelterHomeDTOResponse DeletedList(string userName)
        {
            ShelterHomeDTOResponse shelterHomeDTOResponse = new ShelterHomeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHome_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeDTOResponse.ShelterHomeDTOList = result.Read<ShelterHomeDTOList>().ToList();
                }
            }
            return shelterHomeDTOResponse;
        }

        public ShelterHomeContactDTOAddEditResult ContactAdd(ShelterHomeContactDTOAddDB shelterHomeContactDTOAddDB)
        {
            ShelterHomeContactDTOAddEditResult shelterHomeContactDTOAddEditResult = new ShelterHomeContactDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHome_Contact_Insert_Admin", shelterHomeContactDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeContactDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeContactDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeContactDTOAddEditResult.ShelterHomeContactDTODetail = result.Read<ShelterHomeContactDTODetail>().FirstOrDefault();
                }
            }
            return shelterHomeContactDTOAddEditResult;
        }

        public ShelterHomeContactDTOAddEditResult ContactEdit(ShelterHomeContactDTOEditDB shelterHomeContactDTOEditDB)
        {
            ShelterHomeContactDTOAddEditResult shelterHomeContactDTOAddEditResult = new ShelterHomeContactDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHome_Contact_Update_Admin", shelterHomeContactDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeContactDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeContactDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeContactDTOAddEditResult.ShelterHomeContactDTODetail = result.Read<ShelterHomeContactDTODetail>().FirstOrDefault();
                }
            }
            return shelterHomeContactDTOAddEditResult;
        }

        public ShelterHomeContactDTOResponse ContactList(string userName)
        {
            ShelterHomeContactDTOResponse shelterHomeContactDTOResponse = new ShelterHomeContactDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHome_Contact_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeContactDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeContactDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeContactDTOResponse.ShelterHomeContactDTOList = result.Read<ShelterHomeContactDTOList>().ToList();
                }
            }
            return shelterHomeContactDTOResponse;
        }

        public ShelterHomeContactDTODetailResponse ContactDetail(int shelterHomeContactCode, string userName)
        {
            ShelterHomeContactDTODetailResponse shelterHomeContactDTODetailResponse = new ShelterHomeContactDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHome_Contact_GetByCode_Admin", new { ShelterHomeContactCode = shelterHomeContactCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeContactDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeContactDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeContactDTODetailResponse.ShelterHomeContactDTODetail = result.Read<ShelterHomeContactDTODetail>().FirstOrDefault();
                }
            }
            return shelterHomeContactDTODetailResponse;
        }
        public DataUpdateResponseDTO ContactDelete(int shelterHomeContactCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("ShelterHomeContact_Delete_Admin", new { ShelterHomeContactCode = shelterHomeContactCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }
        public ShelterHomeContactDTOResponse ContactDeletedList(string userName)
        {
            ShelterHomeContactDTOResponse shelterHomeContactDTOResponse = new ShelterHomeContactDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHomeContact_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeContactDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeContactDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeContactDTOResponse.ShelterHomeContactDTOList = result.Read<ShelterHomeContactDTOList>().ToList();
                }
            }
            return shelterHomeContactDTOResponse;
        }
        public ShelterHomeContactChangeLogDTOResponse ContactChangeLog_GetById(int shelterHomeContactCode, string userName)
        {
            ShelterHomeContactChangeLogDTOResponse shelterHomeContactChangeLogDTOResponse = new ShelterHomeContactChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ShelterHomeContactLog_GetByCode_Admin", new { ShelterHomeContactCode = shelterHomeContactCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    shelterHomeContactChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (shelterHomeContactChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    shelterHomeContactChangeLogDTOResponse.ShelterHomeContactChangeLogDTOList = result.Read<ShelterHomeContactChangeLogDTOList>().ToList();
                }
            }
            return shelterHomeContactChangeLogDTOResponse;
        }
    }
}