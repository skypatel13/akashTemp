using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class CITRegisterResponse
    {
        public DataUpdateResponseDTO dataUpdateResponseDTO { get; set; }
        public List<CITRegisterReport> citRegisterReports { get; set; }
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
            status += $"CIT Register Report Count:{this.citRegisterReports.Count}";
            return status;
        }
    }
    public class CITRegisterReport
    {
        public int PartnerCode { get; set; }
        public string PartnerName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public int MemberCode { get; set; }
        public string SocialWorker { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public DateTime TraffickingDate { get; set; }
        public int AgeWhenTrafficked { get; set; }
        public string Rescue { get; set; }
        public DateTime? RescueDate { get; set; }
        public int? AgeWhenRescue { get; set; }
        public int? MonthsBetweenTraffickedAndRescued { get; set; }
        public int? MonthsSinceRescued { get; set; }
        public int MonthSinceTrafficked { get; set; }
        public int policeStationCode { get; set; }
        public string PoliceStationName { get; set; }
        public string State { get; set; }
        public int StateCode { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int BlockCode { get; set; }
        public string Block { get; set; }
        public int VillageCode { get; set; }
        public string Village { get; set; }
        public DateTime CITDate { get; set; }
        public DateTime NextAssessmentDate { get; set; }
        public int? Score { get; set; }
        public string IsApproved { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string ApprovedBy { get; set; }
        public int? ObjectiveCount { get; set; }
        public string Objectives { get; set; }
        public int? ActivityCount { get; set; }
        public string Activity { get; set; }
        public int? BasicNeeds { get; set; }
        public int? PhysicalHealth { get; set; }
        public int? EmotionalHealth { get; set; }
        public int? Education { get; set; }
        public int? WorkIncome { get; set; }
        public int? FamilyRelation { get; set; }
        public int? SocialRelation { get; set; }
        public int? RecreationalNeeds { get; set; }
        public int? LegalAid { get; set; }
        public int? NeedsStigma { get; set; }
        public int? TotalCITCount { get; set; }
        public DateTime? FirstCITDate { get; set; }
        public DateTime? LastCITDate { get; set; }
        public string SurvivorUpdatedBy { get; set; }
        public string SurvivorUpdatedOn { get; set; }
        public string SurvivorCreatedBy { get; set; }
        public string SurvivorCreatedOn { get; set; }
        public string RescueCreatedBy { get; set; }
        public string RescueCreatedOn { get; set; }
        public string RescueUpdatedBy { get; set; }
        public string RescueUpdatedOn { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
