using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ISurvivorCit
    {
        SurvivorCitDTOResponse List(int survivorCode, string userName);
        SurvivorCitDTOAddEditResult Add(SurvivorCitAssessmentDTOAddDB survivorCitAssessmentDTOAddDB);
        DataUpdateResponseDTO AddAnswer(SurvivorCitAnswerAddDB survivorCitAnswerAddDB);
        SurvivorCitActionResponse CitActionList(int surAsmtCode, string userName);
        DataUpdateResponseDTO AssessmentSubmit(SurvivorCitAssessmentSubmitDTODB survivorCitAssessmentSubmitDTOSubmitDB);
        DataUpdateResponseDTO AddAction(SurvivorCitAssessmentActionDTOAddDB survivorCitActionDTOAddDB);
        DataUpdateResponseDTO EditAction(SurvivorCitAssessmentActionDTOEditDB survivorCitActionDTOEditDB);
        SurvivorCitActionDetailResponse DetailAction(int surAsmtActCode, string userName);
        DataUpdateResponseDTO DeleteAction(int surAsmtActCode, string deletedBy, string deletedByIpAddress);
        DataUpdateResponseDTO UpdateDimensionScore(SurvivorCitDimensionScoreEditDB survivorCitDimensionScoreEditDB);
        SurvivorCitDTODetailResponse Detail(int surAsmtCode, string UserName);
        DataUpdateResponseDTO Delete(int surAsmtCode, string deletedBy, string deletedByIpAddress);
        DataUpdateResponseDTO SubActionAdd(SurvivorCitSubActionAddDTODB survivorCitSubActionAddDTODB);
        DataUpdateResponseDTO SubActionDelete(int surAsmtSubActCode,string deletedBy,string deletedByIpAddress);
        DataUpdateResponseDTO SurvivorCITStatus_Insert_Admin(CitStatusRequestDTODB citStatusRequestDTODB);
        DataUpdateResponseDTO SurvivorCITStatus_Update_Admin(CitStatusResponseDTODB citStatusResponseDTODB);
        CitStatusLogDTOResponse SurvivorCITStatus_ListByCode(int survivorCode, string userName);
        DataUpdateResponseDTO Section11Submit(SurvivorCitSection11SubmitDTODB survivorCitSection11SubmitDTODB);
        DataUpdateResponseDTO DeptDutyBearerAdd(CitDeptDutyBearerAddDTODB citDeptDutyBearerAddDTODB);
        SurvivorCitSubActionResponse CitSubActionList(int surAsmtActCode, string userName);
        SurvivorCitPlanDimResponse CitPlanDimensionList(int surAsmtCode, string userName);
        DataUpdateResponseDTO CitPlannedDimensionAdd(CitPlannedDimensionAddDTODB citPlannedDimensionAddDTODB);
        DataUpdateResponseDTO SurvivorCITObservation_Update_Admin(CitObservationUpdateDTODB citObservationUpdateDTODB);
        SurvivorCitStarReportDTOResponse Star_Report_GetByCode(int survivorCode, string userName);
        SurvivorCitChangeLogResponse ChangeLog_GetById(int surAsmtCode, string userName);
        SurvivorCitDTOResponse DeletedList(int survivorCode, string userName);
    }
}
