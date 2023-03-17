using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class VCRegisterResponse
    {
        public DataUpdateResponseDTO dataUpdateResponseDTO { get; set; }
        public List<VCRegisterReport> vcRegisterReports { get; set; }
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
            status += $"VC Register Report Count:{this.vcRegisterReports.Count}";
            return status;
        }
    }
    public class VCRegisterReport
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
        public int VCCode { get; set; }
        public string SourceDestination { get; set; }
        public string IsConcluded { get; set; }
        public string CurrentStatus { get; set; }
        public string CurrentEscalatedStatus { get; set; }
        public int TotalAmountAwarded { get; set; }
        public string AllottedLawyers { get; set; }
        public int LawyerCode { get; set; }
        public string ApplicationLawyer { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationNumber { get; set; }
        public string AppliedAt { get; set; }
        public string Authority { get; set; }
        public int AmountClaimed { get; set; }
        public string IsOrderReceived { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
        public int? AmountAwarded { get; set; }
        public int? AmountDifference { get; set; }
        public string IsAmountReceived { get; set; }
        public int? AmountReceivedBank { get; set; }
        public DateTime? AmountReceivedDate { get; set; }
        public int? TimeTakenVC { get; set; }
        public string IsEscalationRequired { get; set; }
        public string EscalationReason { get; set; }
        public string AppealLawyer { get; set; }
        public DateTime? AppealApplicationDate { get; set; }
        public string AppealApplicationNumber { get; set; }
        public string AppealAppliedAt { get; set; }
        public string AppealAuthority { get; set; }
        public int? AppealAmountClaimed { get; set; }
        public string IsAppealOrderReceived { get; set; }
        public DateTime? AppealOrderDate { get; set; }
        public string AppealStatus { get; set; }
        public string AppealResult { get; set; }
        public int? AppealAmountAwarded { get; set; }
        public int? AppealAmountDifference { get; set; }
        public string IsAppealAmountReceived { get; set; }
        public int? AppealAmountReceivedBank { get; set; }
        public DateTime? AppealAmountReceivedDate { get; set; }
        public int? AppealTimeTakenVC { get; set; }
        public string IsAppealEscalationRequired { get; set; }
        public string AppealEscalationReason { get; set; }
        public string WritLawyer { get; set; }
        public DateTime? WritApplicationDate { get; set; }
        public string WritApplicationNumber { get; set; }
        public string WritAppliedAt { get; set; }
        public string WritAuthority { get; set; }
        public int? WritAmountClaimed { get; set; }
        public string IsWritOrderReceived { get; set; }
        public DateTime? WritOrderDate { get; set; }
        public string WritStatus { get; set; }
        public string WritResult { get; set; }
        public int? WritAmountAwarded { get; set; }
        public int? WritAmountDifference { get; set; }
        public string IsWritAmountReceived { get; set; }
        public int? WritAmountReceivedBank { get; set; }
        public DateTime? WritAmountReceivedDate { get; set; }
        public int? WritTimeTakenVC { get; set; }
        public string IsWritEscalationRequired { get; set; }
        public string WritEscalationReason { get; set; }
       
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
