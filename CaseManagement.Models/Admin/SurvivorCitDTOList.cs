using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitDTOResponse
    {
        public DataUpdateResponseDTO dataUpdateResponseDTO { get; set; }
        public List<SurvivorCitDTOList> survivorCitDTOLists { get; set; }
        public override string ToString()
        {
            if (this.dataUpdateResponseDTO == null)
            {
                return $"No status available";
            }
            string status = dataUpdateResponseDTO.ToString();
            if (this.dataUpdateResponseDTO.Status == false)
            {
                return status;
            }
            status += $"Survivor CIT List Count:{this.survivorCitDTOLists.Count}";
            return status;
        }
    }
    public class SurvivorCitDTOList
    {
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public string Organization { get; set; }
        public int SurAsmtCode { get; set; }
        public int VersionCode { get; set; }
        public DateTime CitDate { get; set; }
        public int Score { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string IsApproved { get; set; }
        public DateTime NextAssessmentDate { get; set; }
        public string StrengthResource { get; set; }
        public string WorryStatement { get; set; }
        public string GoalStatement { get; set; }
        public string Observation { get; set; }
        public int ApprovalStatusCode { get; set; }
        public string ApprovalStatus { get; set; }
        public Nullable<bool> IsParentPresentValue { get; set; }
        public string IsParentPresentText { get; set; }
        public string RolePlay { get; set; }
        public string CareGiverOpinion { get; set; }
        public string CareGiverFeedback { get; set; }
        public bool IsFirstStepCompleted { get; set; }
        public bool IsPlannedDimension { get; set; }
        public bool IsObjectiveAdded { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
