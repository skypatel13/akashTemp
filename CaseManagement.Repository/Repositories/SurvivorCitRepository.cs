using CaseManagement.DAL;
using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Repository.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CaseManagement.Repository.Repositories
{
    public class SurvivorCitRepository : ISurvivorCit
    {
        private readonly AppConnectionString appConnectionString;
        public SurvivorCitRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public SurvivorCitDTOResponse List(int survivorCode, string userName)
        {
            SurvivorCitDTOResponse survivorCitDTOResponse = new SurvivorCitDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Survivor_CIT_List_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorCitDTOResponse.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorCitDTOResponse.dataUpdateResponseDTO.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorCitDTOResponse.survivorCitDTOLists = result.Read<SurvivorCitDTOList>().ToList();
                    }

                }
            }
            return survivorCitDTOResponse;
        }
        public SurvivorCitDTOAddEditResult Add(SurvivorCitAssessmentDTOAddDB survivorCitAssessmentDTOAddDB)
        {
            SurvivorCitDTOAddEditResult survivorCitDTOAddEditResult = new SurvivorCitDTOAddEditResult();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Survivor_Assessment_Insert_Admin", survivorCitAssessmentDTOAddDB, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorCitDTOAddEditResult.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorCitDTOAddEditResult.dataUpdateResponseDTO.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorCitDTOAddEditResult.survivorCitDTODetail = result.Read<SurvivorCitDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitDTOAddEditResult.survivorCitDimension = result.Read<SurvivorCitDimension>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitDTOAddEditResult.survivorCitDimensionQuestions = result.Read<SurvivorCitDimensionQuestion>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitDTOAddEditResult.survivorCitDimensionQuestionOptions = result.Read<SurvivorCitDimensionQuestionOption>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitDTOAddEditResult.survivorCitActionDTOLists = result.Read<SurvivorCitActionDTOList>().ToList();
                    }
                }
            }
            return survivorCitDTOAddEditResult;
        }
        public DataUpdateResponseDTO AddAnswer(SurvivorCitAnswerAddDB survivorCitAnswerAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {

                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Answer_Insert_Admin", survivorCitAnswerAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO AssessmentSubmit(SurvivorCitAssessmentSubmitDTODB survivorCitAssessmentSubmitDTOSubmitDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {

                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_Submit_Admin", survivorCitAssessmentSubmitDTOSubmitDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SurvivorCitActionResponse CitActionList(int surAsmtCode, string userName)
        {
            SurvivorCitActionResponse survivorCitActionResponse = new SurvivorCitActionResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Survivor_CITAction_List_Admin", new { SurAsmtCode = surAsmtCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorCitActionResponse.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorCitActionResponse.dataUpdateResponseDTO.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorCitActionResponse.survivorCitActionDTOLists = result.Read<SurvivorCitActionDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitActionResponse.survivorCitSubActionListDTOLists = result.Read<SurvivorCitSubActionListDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitActionResponse.survivorCitDimensionQuestions = result.Read<SurvivorCitDimensionQuestion>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitActionResponse.survivorCitDimensionQuestionOptions = result.Read<SurvivorCitDimensionQuestionOption>().ToList();
                    }
                }
            }
            return survivorCitActionResponse;
        }
        public DataUpdateResponseDTO AddAction(SurvivorCitAssessmentActionDTOAddDB survivorCitActionDTOAddDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_ActionInsert_Admin", survivorCitActionDTOAddDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO EditAction(SurvivorCitAssessmentActionDTOEditDB survivorCitActionDTOEditDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_ActionUpdate_Admin", survivorCitActionDTOEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SurvivorCitActionDetailResponse DetailAction(int surAsmtActCode, string userName)
        {
            SurvivorCitActionDetailResponse survivorCitActionDetailResponse = new SurvivorCitActionDetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Survivor_Assessment_ActionGetByCode_Admin", new { SurAsmtActCode = surAsmtActCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorCitActionDetailResponse.dataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorCitActionDetailResponse.dataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorCitActionDetailResponse.survivorCitActionDTODetail = result.Read<SurvivorCitActionDTODetail>().FirstOrDefault();
                    }
                }
            }
            return survivorCitActionDetailResponse;

        }
        public DataUpdateResponseDTO DeleteAction(int surAsmtActCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_ActionDelete_Admin", new { SurAsmtActCode = surAsmtActCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO UpdateDimensionScore(SurvivorCitDimensionScoreEditDB survivorCitDimensionScoreEditDB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_DimensionScoreUpdate_Admin", survivorCitDimensionScoreEditDB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public SurvivorCitDTODetailResponse Detail(int surAsmtCode, string UserName)
        {
            SurvivorCitDTODetailResponse survivorCitDTODetailResponse = new SurvivorCitDTODetailResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Survivor_Assessment_GetByCode_Admin", new { SurAsmtCode = surAsmtCode, UserName = UserName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorCitDTODetailResponse.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorCitDTODetailResponse.dataUpdateResponseDTO.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorCitDTODetailResponse.survivorCitDTODetail = result.Read<SurvivorCitDTODetail>().FirstOrDefault();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitDTODetailResponse.survivorCitDimension = result.Read<SurvivorCitDimension>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitDTODetailResponse.survivorCitDimensionQuestions = result.Read<SurvivorCitDimensionQuestion>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitDTODetailResponse.survivorCitDimensionQuestionOptions = result.Read<SurvivorCitDimensionQuestionOption>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitDTODetailResponse.survivorCitActionDTOLists = result.Read<SurvivorCitActionDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitDTODetailResponse.deptDutyBearerDTOLists = result.Read<CitDeptDutyBearerDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitDTODetailResponse.survivorCitSubActionListDTOLists = result.Read<SurvivorCitSubActionListDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitDTODetailResponse.CitStatusLogDTO = result.Read<CitStatusLogDTO>().ToList();
                    }
                }
                survivorCitDTODetailResponse.dimensionQuestionDTOs = new List<DimensionQuestionDTO>();
                foreach (var dimension in survivorCitDTODetailResponse.survivorCitDimension)
                {

                    survivorCitDTODetailResponse.dimensionQuestionDTOs.Add(new DimensionQuestionDTO()
                    {
                        SurAsmtDimCode = dimension.SurAsmtDimCode,
                        SurAsmtCode = dimension.SurAsmtCode,
                        VersionDimensionCode = dimension.VersionDimensionCode,
                        DimensionName = dimension.DimensionName,
                        Score = dimension.Score,
                        survivorCitDimensionQuestions = survivorCitDTODetailResponse.survivorCitDimensionQuestions.Where(C => C.SurAsmtDimCode == dimension.SurAsmtDimCode).ToList(),
                        deptDutyBearerDTOLists = survivorCitDTODetailResponse.deptDutyBearerDTOLists.Where(c => c.SurAsmtDimCode == dimension.SurAsmtDimCode).ToList()
                    }); ;
                }
                survivorCitDTODetailResponse.questionOptionsDTOs = new List<QuestionOptionsDTO>();
                foreach (var dimension in survivorCitDTODetailResponse.survivorCitDimensionQuestions)
                {

                    survivorCitDTODetailResponse.questionOptionsDTOs.Add(new QuestionOptionsDTO()
                    {
                        SurAsmtDimQueCode = dimension.SurAsmtDimQueCode,
                        survivorCitDimensionQuestionOptions = survivorCitDTODetailResponse.survivorCitDimensionQuestionOptions.Where(C => C.SurAsmtDimQueCode == dimension.SurAsmtDimQueCode).ToList()
                    });
                }
            }
            return survivorCitDTODetailResponse;
        }

        public DataUpdateResponseDTO Delete(int surAsmtCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_CIT_Delete_Admin", new { SurAsmtCode = surAsmtCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO SubActionAdd(SurvivorCitSubActionAddDTODB survivorCitSubActionAddDTODB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_SubActionInsert_Admin", survivorCitSubActionAddDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO SubActionDelete(int surAsmtSubActCode, string deletedBy, string deletedByIpAddress)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_SubActionDelete_Admin ", new { SurAsmtSubActCode = surAsmtSubActCode, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO SurvivorCITStatus_Insert_Admin(CitStatusRequestDTODB citStatusRequestDTODB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_ApprovalInsert_Admin", citStatusRequestDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO SurvivorCITStatus_Update_Admin(CitStatusResponseDTODB citStatusResponseDTODB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_ApprovalUpdate_Admin", citStatusResponseDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public CitStatusLogDTOResponse SurvivorCITStatus_ListByCode(int surAsmtCode, string userName)
        {
            CitStatusLogDTOResponse tafteeshStatusLogDTOResponse = new CitStatusLogDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Survivor_Assessment_ApprovalLogList_Admin", new { SurAsmtCode = surAsmtCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    tafteeshStatusLogDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (tafteeshStatusLogDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        tafteeshStatusLogDTOResponse.CitStatusLogDTO = result.Read<CitStatusLogDTO>().ToList();
                    }
                }
            }
            return tafteeshStatusLogDTOResponse;
        }
        public DataUpdateResponseDTO Section11Submit(SurvivorCitSection11SubmitDTODB survivorCitSection11SubmitDTODB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_CareGiver_Update_Admin ", survivorCitSection11SubmitDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO DeptDutyBearerAdd(CitDeptDutyBearerAddDTODB citDeptDutyBearerAddDTODB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_DepartmentDutyBearer_Insert_Admin", citDeptDutyBearerAddDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SurvivorCitSubActionResponse CitSubActionList(int surAsmtActCode, string userName)
        {
            SurvivorCitSubActionResponse survivorCitSubActionResponse = new SurvivorCitSubActionResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Survivor_Assessment_SubAction_List_Admin", new { SurAsmtActCode = surAsmtActCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorCitSubActionResponse.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorCitSubActionResponse.dataUpdateResponseDTO.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorCitSubActionResponse.survivorCitSubActionListDTOLists = result.Read<SurvivorCitSubActionListDTOList>().ToList();
                    }
                }
            }
            return survivorCitSubActionResponse;
        }
        public SurvivorCitPlanDimResponse CitPlanDimensionList(int surAsmtCode, string userName)
        {
            SurvivorCitPlanDimResponse survivorCitPlanDimResponse = new SurvivorCitPlanDimResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Survivor_Assessment_Dimension_List_Admin", new { SurAsmtCode = surAsmtCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorCitPlanDimResponse.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorCitPlanDimResponse.dataUpdateResponseDTO.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorCitPlanDimResponse.SurvivorCitPlanDimDTOList = result.Read<SurvivorCitPlanDimDTOList>().ToList();
                    }
                }
            }
            return survivorCitPlanDimResponse;
        }
        public DataUpdateResponseDTO CitPlannedDimensionAdd(CitPlannedDimensionAddDTODB citPlannedDimensionAddDTODB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_Planning_Insert_Admin", citPlannedDimensionAddDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public DataUpdateResponseDTO SurvivorCITObservation_Update_Admin(CitObservationUpdateDTODB citObservationUpdateDTODB)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("CIT.Survivor_Assessment_Observation_Update_Admin", citObservationUpdateDTODB, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public SurvivorCitStarReportDTOResponse Star_Report_GetByCode(int survivorCode, string userName)
        {
            SurvivorCitStarReportDTOResponse survivorCitStarReportDTOResponse = new SurvivorCitStarReportDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.StarReport_GetBySurvivorCode_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorCitStarReportDTOResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorCitStarReportDTOResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorCitStarReportDTOResponse.SurvivorCitDimensionList = result.Read<SurvivorCitDimensionDTOList>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitStarReportDTOResponse.SurvivorCitStarReportList = result.Read<SurvivorCitStarReportDTOList>().ToList();
                    }
                    
                }
            }
            return survivorCitStarReportDTOResponse;
        }
        public SurvivorCitChangeLogResponse ChangeLog_GetById(int surAsmtCode, string userName)
        {
            SurvivorCitChangeLogResponse survivorCitChangeLogResponse = new SurvivorCitChangeLogResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Survivor_CITLog_GetByCode_Admin", new { SurAsmtCode = surAsmtCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorCitChangeLogResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorCitChangeLogResponse.DataUpdateResponse.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorCitChangeLogResponse.SurvivorCitChangeLogs = result.Read<SurvivorCitChangeLogDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitChangeLogResponse.survivorCitDimensionScoreChangeLogs = result.Read<SurvivorCitDimensionScoreChangeLogDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitChangeLogResponse.survivorCitDimensionQuestionChangeLogs = result.Read<SurvivorCitDimensionQuestionChangeLogDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitChangeLogResponse.survivorCitDutyBearerDeparmentChangeLogs = result.Read<SurvivorCitDutyBearerDeparmentChangeLogDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitChangeLogResponse.survivorCitPlannedDimensionChangeLogs = result.Read<SurvivorCitPlannedDimensionChangeLogDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitChangeLogResponse.survivorCitPlannedObjectiveChangeLogs = result.Read<SurvivorCitPlannedObjectiveChangeLogDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitChangeLogResponse.survivorCitPlannedSubActivityChangeLogs = result.Read<SurvivorCitPlannedSubActivityChangeLogDTO>().ToList();
                    }
                    if (!result.IsConsumed)
                    {
                        survivorCitChangeLogResponse.survivorCitApprovalChangeLogs = result.Read<SurvivorCitApprovalChangeLogDTO>().ToList();
                    }
                }
            }
            return survivorCitChangeLogResponse;
        }
        public SurvivorCitDTOResponse DeletedList(int survivorCode, string userName)
        {
            SurvivorCitDTOResponse survivorCitDTOResponse = new SurvivorCitDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("CIT.Survivor_CIT_Deleted_List_Admin", new { SurvivorCode = survivorCode, UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    survivorCitDTOResponse.dataUpdateResponseDTO = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (survivorCitDTOResponse.dataUpdateResponseDTO.Status == true)
                {
                    if (!result.IsConsumed)
                    {
                        survivorCitDTOResponse.survivorCitDTOLists = result.Read<SurvivorCitDTOList>().ToList();
                    }

                }
            }
            return survivorCitDTOResponse;
        }
    }
}
