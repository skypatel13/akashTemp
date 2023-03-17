using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitChangeLogResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorCitChangeLogDTO> SurvivorCitChangeLogs { get; set; }
        public List<SurvivorCitDimensionScoreChangeLogDTO> survivorCitDimensionScoreChangeLogs { get; set; }
        public List<SurvivorCitDimensionQuestionChangeLogDTO> survivorCitDimensionQuestionChangeLogs { get; set; }
        public List<SurvivorCitDutyBearerDeparmentChangeLogDTO> survivorCitDutyBearerDeparmentChangeLogs { get; set; }
        public List<SurvivorCitPlannedDimensionChangeLogDTO> survivorCitPlannedDimensionChangeLogs { get; set; }
        public List<SurvivorCitPlannedObjectiveChangeLogDTO> survivorCitPlannedObjectiveChangeLogs { get; set; }
        public List<SurvivorCitPlannedSubActivityChangeLogDTO> survivorCitPlannedSubActivityChangeLogs { get; set; }
        public List<SurvivorCitApprovalChangeLogDTO> survivorCitApprovalChangeLogs { get; set; }
        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Survivor Cit Log Count:{this.SurvivorCitChangeLogs.Count}";
            status += $"Survivor Cit Dimension Score Log Count:{this.survivorCitDimensionScoreChangeLogs.Count}";
            status += $"Survivor Cit Dimension Question Log Count:{this.survivorCitDimensionQuestionChangeLogs.Count}";
            status += $"Survivor Cit Duty Bearer Department Log Count:{this.survivorCitDutyBearerDeparmentChangeLogs.Count}";
            status += $"Survivor Cit Planned Dimension Log Count:{this.survivorCitPlannedDimensionChangeLogs.Count}";
            status += $"Survivor Cit Planned Objectived Log Count:{this.survivorCitPlannedObjectiveChangeLogs.Count}";
            status += $"Survivor Cit Planned Sub Activity Log Count:{this.survivorCitPlannedSubActivityChangeLogs.Count}";
            status += $"Survivor Cit Approval Log Count:{this.survivorCitApprovalChangeLogs.Count}";
            return status;
        }
    }
    public class SurvivorCitChangeLogDTO
    {
        public int SurAsmtCode { get; set; }
        public int SurvivorCode { get; set; }
        public int VersionCode { get; set; }
        public DateTime CitDate { get; set; }
        public int Score { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string IsApproved { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime NextAssessmentDate { get; set; }
        public string StrengthResource { get; set; }
        public string WorryStatement { get; set; }
        public string GoalStatement { get; set; }
        public string Observation { get; set; }
        public int ApprovalStatusCode { get; set; }
        public string ApprovalStatus { get; set; }
        public string IsParentPresent { get; set; }
        public string RolePlay { get; set; }
        public string CareGiverOpinion { get; set; }
        public string CareGiverFeedback { get; set; }
        public string IsFirstStepCompleted { get; set; }
        public string IsPlannedDimension { get; set; }
        public string IsObjectiveAdded { get; set; }
        public string CreatedBy { get; set; }
        public string SocialWorkerName { get; set; }
        public string IsDeleted { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string PoliceStationName { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorCitDimensionScoreChangeLogDTO
    {
        public int SurAsmtDimCode { get; set; }
        public int SurAsmtCode { get; set; }
        public int VersionDimensionCode { get; set; }
        public string DimensionName { get; set; }
        public int Score { get; set; }
        public string IsDeleted { get; set; }
        public DateTime CitDate { get; set; }
        public string IsApproved { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime NextAssessmentDate { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string PoliceStationName { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorCitDimensionQuestionChangeLogDTO
    {
        public int SurAsmtDimQueCode { get; set; }
        public int SurAsmtDimCode { get; set; }
        public int VersionDimensionQuestionCode { get; set; }
        public string Question { get; set; }
        public string QuestionUIControlType { get; set; }
        public string Answer { get; set; }
        public string DimensionName { get; set; }
        public DateTime CitDate { get; set; }
        public string IsDeleted { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string PoliceStationName { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorCitDutyBearerDeparmentChangeLogDTO
    {
        public int SurAsmtDutyBearerCode { get; set; }
        public DateTime CitDate { get; set; }
        public int SurAsmtDimCode { get; set; }
        public string DimensionName { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public int DutyBearerCode { get; set; }
        public string DutyBearer { get; set; }
        public string IsDeleted { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string PoliceStationName { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorCitPlannedDimensionChangeLogDTO
    {
        public int SurAsmtPlanningCode { get; set; }
        public int SurAsmtDimCode { get; set; }
        public int SurAsmtCode { get; set; }
        public string DimensionName { get; set; }
        public string IsDeleted { get; set; }
        public DateTime CitDate { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string PoliceStationName { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorCitPlannedObjectiveChangeLogDTO
    {
        public int SurAsmtActCode { get; set; }
        public int SurAsmtDimCode { get; set; }
        public string DimensionName { get; set; }
        public string Action { get; set; }
        public DateTime TargetedDate { get; set; }
        public bool StatusCode { get; set; }
        public string Status { get; set; }
        public DateTime CitDate { get; set; }
        public string IsDeleted { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string PoliceStationName { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
    public class SurvivorCitPlannedSubActivityChangeLogDTO
    {
        public int SurAsmtSubActCode { get; set; }
        public int SurAsmtActCode { get; set; }
        public string Activity { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public int DutyBearerCode { get; set; }
        public string DutyBearer { get; set; }
        public DateTime TargetedDate { get; set; }
        public string Action { get; set; }
        public DateTime ActionTargetedDate { get; set; }
        public string DimensionName { get; set; }
        public DateTime CitDate { get; set; }
        public string IsDeleted { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string PoliceStationName { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorCitApprovalChangeLogDTO
    {
        public int SurAsmtApprovalLogCode { get; set; }
        public int SurAsmtCode { get; set; }
        public int ApprovalStatusCode { get; set; }
        public string ApprovalStatus { get; set; }
        public string ApprovalStatusNotes { get; set; }
        public DateTime CitDate { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string PoliceStationName { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
