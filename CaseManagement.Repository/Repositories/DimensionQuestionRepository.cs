using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CaseManagement.Repository.Repositories
{
    public class DimensionQuestionRepository : IDimensionQuestion
    {
        private readonly AppConnectionString appConnectionString;
        public DimensionQuestionRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public DimensionQuestionDTOResponse List(string userName)
        {
            DimensionQuestionDTOResponse questionDTOResponse = new DimensionQuestionDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.DimensionQuestion_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    questionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (questionDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    questionDTOResponse.DimensionQuestionDTOList = result.Read<DimensionQuestionDTOList>().ToList();
                }
            }
            return questionDTOResponse;
        }
        public DimensionQuestionDTOAddEditResult Add(DimensionQuestionDTOAddDB dimensionQuestionDTOAddDB)
        {
            DimensionQuestionDTOAddEditResult questionDTOAddEditResult = new DimensionQuestionDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.DimensionQuestion_Insert_Admin", dimensionQuestionDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    questionDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (questionDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    questionDTOAddEditResult.DimensionQuestionDTODetail = result.Read<DimensionQuestionDTODetail>().FirstOrDefault();
                }
                if (questionDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    questionDTOAddEditResult.DimensionQuestionDTODetail.DimensionQuestionOptionDTOList = result.Read<DimensionQuestionOptionDTOList>().ToList();
                }
            }
            return questionDTOAddEditResult;
        }

        public DimensionQuestionDTOAddEditResult Edit(DimensionQuestionDTOEditDB dimensionQuestionDTOEditDB)
        {
            DimensionQuestionDTOAddEditResult questionDTOAddEditResult = new DimensionQuestionDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.DimensionQuestion_Update_Admin", dimensionQuestionDTOEditDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    questionDTOAddEditResult.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (questionDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    questionDTOAddEditResult.DimensionQuestionDTODetail = result.Read<DimensionQuestionDTODetail>().FirstOrDefault();
                }
                if (questionDTOAddEditResult.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    questionDTOAddEditResult.DimensionQuestionDTODetail.DimensionQuestionOptionDTOList = result.Read<DimensionQuestionOptionDTOList>().ToList();
                }
            }
            return questionDTOAddEditResult;
        }

        public DataUpdateResponseDTO Delete(int dimensionQuestionCode, string deletedBy, string deletedByIpAddress)
        {
            using IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString);
            return cnn.Query<DataUpdateResponseDTO>("CIT.DimensionQuestion_Delete_Admin", new { DimensionQuestionCode = dimensionQuestionCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
        }

        public QuestionDTODetailResponse Detail(int dimensionQuestionCode, string userName)
        {
            QuestionDTODetailResponse questionDTODetailResponse = new QuestionDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.DimensionQuestion_GetByCode_Admin", new { dimensionQuestionCode = dimensionQuestionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    questionDTODetailResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (questionDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    questionDTODetailResponse.DimensionQuestionDTODetail = result.Read<DimensionQuestionDTODetail>().FirstOrDefault();
                }
                if (questionDTODetailResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    questionDTODetailResponse.DimensionQuestionDTODetail.DimensionQuestionOptionDTOList = result.Read<DimensionQuestionOptionDTOList>().ToList();
                }
            }
            return questionDTODetailResponse;
        }

        public DimensionQuestionChangeLogDTOResponse ChangeLog_GetById(int dimensionQuestionCode, string userName)
        {
            DimensionQuestionChangeLogDTOResponse questionChangeLogDTOResponse = new DimensionQuestionChangeLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.DimensionQuestionLog_GetByCode_Admin", new { dimensionQuestionCode = dimensionQuestionCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    questionChangeLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (questionChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    questionChangeLogDTOResponse.DimensionQuestionChangeLogDTOList = result.Read<DimensionQuestionChangeLogDTOList>().ToList();
                }
                if (questionChangeLogDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    questionChangeLogDTOResponse.DimensionQuestionOptionChangeLogDTOList = result.Read<DimensionQuestionOptionChangeLogDTOList>().ToList();
                }
            }
            return questionChangeLogDTOResponse;
        }

        public DimensionQuestionDTOResponse DeletedList(string userName)
        {
            DimensionQuestionDTOResponse questionDTOResponse = new DimensionQuestionDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.DimensionQuestion_Deleted_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    questionDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (questionDTOResponse.DataUpdateResponse.Status && !result.IsConsumed)
                {
                    questionDTOResponse.DimensionQuestionDTOList = result.Read<DimensionQuestionDTOList>().ToList();
                }
            }
            return questionDTOResponse;
        }
    }
}
