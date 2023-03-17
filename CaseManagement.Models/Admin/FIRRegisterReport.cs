using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class FIRRegisterResponse
    {
        public DataUpdateResponseDTO dataUpdateResponseDTO { get; set; }
        public List<FIRRegisterReport> fIRRegisterReports { get; set; }
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
            status += $"FIR Register Report Count:{this.fIRRegisterReports.Count}";
            return status;
        }
    }
    public class FIRRegisterReport
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
        public int FIRCode { get; set; }
        public string SourceDestination { get; set; }
        public string FIRPoliceStationName { get; set; }
        public string DeFactoComplainer { get; set; }
        public string RelationWithDeFactoComplainer { get; set; }
        public int NumberOfAccused { get; set; }
        public string GDNumber { get; set; }
        public DateTime? GDDate { get; set; }
        public string GDIssue { get; set; }
        public string GDCopy { get; set; }
        public string GDCopyStoredAs { get; set; }
        public string FIRNumber { get; set; }
        public DateTime FIRDate { get; set; }
        public string FIRIssue { get; set; }
        public string FIRCopy { get; set; }
        public string FIRCopyStoredAs { get; set; }
        public string ActSection { get; set; }
        public string TraffickerName { get; set; }
        public string InvestingAgencyType { get; set; }
        public string InvestingAgency { get; set; }
        public string OfficerRank { get; set; }
        public string InvestigatingOfficer { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
        public DateTime? ResultDate { get; set; }
        public string ResultChallenged { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public string AcceptanceReason { get; set; }
        public int ChargeSheetCode { get; set; }
        public string ChargeSheetNumber { get; set; }
        public DateTime? ChargeSheetDate { get; set; }
        public string TypeOfViolation { get; set; }
        public string ChargeSheetSections { get; set; }
        public string ChargeSheetTraffickers { get; set; }
        public string FIRCreatedOn { get; set; }
        public string FIRCreatedBy { get; set; }
        public string FIRModifiedOn { get; set; }
        public string FIRModifiedBy { get; set; }
        public string InvestigationCreatedOn { get; set; }
        public string InvestigationCreatedBy { get; set; }
        public string InvestigationModifiedOn { get; set; }
        public string InvestigationModifiedBy { get; set; }
        public string ChargeSheetCreatedOn { get; set; }
        public string ChargeSheetCreatedBy { get; set; }
        public string ChargeSheetModifiedOn { get; set; }
        public string ChargeSheetModifiedBy { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
