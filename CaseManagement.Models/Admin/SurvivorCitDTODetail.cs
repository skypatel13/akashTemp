using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitDTODetail
    {
        public int SurAsmtCode { get; set; }
        public string SocialWorkerName { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string PoliceStationName { get; set; }
        public int VersionCode { get; set; }
        public DateTime CitDate { get; set; }
        public int Score { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string IsApprovedText { get; set; }
        public bool IsApprovedValue { get; set; }
        public DateTime ApprovedOn { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedByIpAddress { get; set; }
        public DateTime NextAssessmentDate { get; set; }
        public bool IsParentPresentValue { get; set; }
        public string IsParentPresentText { get; set; }
        public string RolePlay { get; set; }
        public string CareGiverOpinion { get; set; }
        public string CareGiverFeedback { get; set; }
        public string StrengthResource { get; set; }
        public string WorryStatement { get; set; }
        public string GoalStatement { get; set; }
        public string Observation { get; set; }
        public string IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
