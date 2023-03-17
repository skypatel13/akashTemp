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
    public class CitDimensionRepository : ICitDimension
    {
        private readonly AppConnectionString appConnectionString;
        public CitDimensionRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public CitDimensionDTOResponse List(string userName, int? versionCode)
        {
            CitDimensionDTOResponse versionDimensionDTOResponse = new CitDimensionDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.VersionDimension_List_Admin", new { UserName = userName, VersionCode = versionCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    versionDimensionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (versionDimensionDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    versionDimensionDTOResponse.CitDimensionDTOList = result.Read<CitDimensionDTOList>().ToList();
                }
            }
            return versionDimensionDTOResponse;
        }
        public DataUpdateResponseDTO Add(CitDimensionDTOAddDB versionDimensionDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.VersionDimension_Insert_Admin", versionDimensionDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public CitDimensionDTODetailResponse Detail(int versionDimensionCode, string userName)
        {
            CitDimensionDTODetailResponse versionDimensionDTODetailResponse = new CitDimensionDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.VersionDimension_GetByCode_Admin", new { VersionDimensionCode = versionDimensionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    versionDimensionDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (versionDimensionDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    versionDimensionDTODetailResponse.CitDimensionDTODetail = result.Read<CitDimensionDTODetail>().FirstOrDefault();
                }
            }
            return versionDimensionDTODetailResponse;
        }
        public CitDimensionChangeLogDTOResponse ChangeLog_GetById(int versionDimensionCode, string userName)
        {
            CitDimensionChangeLogDTOResponse versionDimensionChangeLogDTOResponse = new CitDimensionChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.VersionDimensionLog_GetByCode_Admin", new { VersionDimensionCode = versionDimensionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    versionDimensionChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (versionDimensionChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    versionDimensionChangeLogDTOResponse.CitDimensionChangeLogDTOList = result.Read<CitDimensionChangeLogDTOList>().ToList();
                }
            }
            return versionDimensionChangeLogDTOResponse;
        }
        public CitDimensionQuestionDTOResponse QuestionList(string userName, int? versionDimensionCode)
        {
            CitDimensionQuestionDTOResponse versionDimensionQuestionDTOResponse = new CitDimensionQuestionDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.VersionDimensionQuestion_List_Admin", new { UserName = userName, VersionDimensionCode= versionDimensionCode }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    versionDimensionQuestionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (versionDimensionQuestionDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    versionDimensionQuestionDTOResponse.CitDimensionQuestionDTOList = result.Read<CitDimensionQuestionDTOList>().ToList();
                }
            }
            return versionDimensionQuestionDTOResponse;
        }
        public DataUpdateResponseDTO QuestionAdd(CitDimensionQuestionDTOAddDB versionDimensionQuestionDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.VersionDimensionQuestion_Insert_Admin", versionDimensionQuestionDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public CitDimensionQuestionChangeLogDTOResponse QuestionChangeLog_GetById(string userName, int versionDimensionQuestionCode)
        {
            CitDimensionQuestionChangeLogDTOResponse versionDimensionQuestionChangeLogDTOResponse = new CitDimensionQuestionChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.VersionDimensionQuestionLog_GetByCode_Admin", new { VersionDimensionQuestionCode = versionDimensionQuestionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    versionDimensionQuestionChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (versionDimensionQuestionChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    versionDimensionQuestionChangeLogDTOResponse.CitDimensionQuestionChangeLogDTOList = result.Read<CitDimensionQuestionChangeLogDTOList>().ToList();
                }
            }
            return versionDimensionQuestionChangeLogDTOResponse;
        }

    }
}

