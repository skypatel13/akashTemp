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
    public class LawyerTypeRepository : ILawyerType
    {
        private readonly AppConnectionString appConnectionString;

        public LawyerTypeRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public LawyerTypeDTOAddEditResult Add(LawyerTypeDTOAddDB lawyerTypeDTOAddDB)
        {
            LawyerTypeDTOAddEditResult lawyerTypeDTOAddEditResult = new LawyerTypeDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LawyerType_Insert_Admin", lawyerTypeDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerTypeDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerTypeDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        lawyerTypeDTOAddEditResult.LawyerTypeDTODetail = result.Read<LawyerTypeDTODetail>().FirstOrDefault();
                    }
                }
            }
            return lawyerTypeDTOAddEditResult;
        }
        public LawyerTypeDTOAddEditResult Edit(LawyerTypeDTOEditDB lawyerTypeDTOEditDB)
        {
            LawyerTypeDTOAddEditResult lawyerTypeDTOAddEditResult = new LawyerTypeDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LawyerType_Update_Admin", lawyerTypeDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerTypeDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerTypeDTOAddEditResult.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        lawyerTypeDTOAddEditResult.LawyerTypeDTODetail = result.Read<LawyerTypeDTODetail>().FirstOrDefault();
                    }
                }
            }
            return lawyerTypeDTOAddEditResult;
        }

        public LawyerTypeDTOResponse List(string userName)
        {
            LawyerTypeDTOResponse lawyerTypeDTOResponse = new LawyerTypeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LawyerType_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerTypeDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerTypeDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        lawyerTypeDTOResponse.LawyerTypeDTOList = result.Read<LawyerTypeDTOList>().ToList();
                    }
                }
            }
            return lawyerTypeDTOResponse;
        }
        public LawyerTypeDTOResponse DeletedList(string userName)
        {
            LawyerTypeDTOResponse lawyerTypeDTOResponse = new LawyerTypeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LawyerType_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerTypeDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerTypeDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        lawyerTypeDTOResponse.LawyerTypeDTOList = result.Read<LawyerTypeDTOList>().ToList();
                    }
                }
            }
            return lawyerTypeDTOResponse;
        }

        public LawyerTypeDTODetailResponse Detail(int lawyerTypeCode, string userName)
        {
            LawyerTypeDTODetailResponse lawyerTypeDTODetailResponse = new LawyerTypeDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LawyerType_GetByCode_Admin", new { LawyerTypeCode = lawyerTypeCode, UserName = userName}, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerTypeDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerTypeDTODetailResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        lawyerTypeDTODetailResponse.LawyerTypeDTODetail = result.Read<LawyerTypeDTODetail>().FirstOrDefault();
                    }
                }
            }
            return lawyerTypeDTODetailResponse;
        }
        public LawyerTypeChangeLogDTOResponse ChangeLog_GetById(int lawyerTypeCode, string userName)
        {
            LawyerTypeChangeLogDTOResponse lawyerTypeLogDTOResponse = new LawyerTypeChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("LawyerTypeLog_GetByCode_Admin", new { LawyerTypeCode = lawyerTypeCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    lawyerTypeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (lawyerTypeLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        lawyerTypeLogDTOResponse.LawyerTypeChangeLogDTOList = result.Read<LawyerTypeChangeLogDTOList>().ToList();
                    }
                }
            }
            return lawyerTypeLogDTOResponse;
        }
        public DataUpdateResponseDTO Delete(int lawyerTypeCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("LawyerType_Delete_Admin", new { LawyerTypeCode = lawyerTypeCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}