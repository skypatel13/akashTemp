using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorRegisterResponse
    {
        public DataUpdateResponseDTO dataUpdateResponseDTO { get; set; }
        public List<SurvivorRegisterReport> survivorRegisterReports { get; set; }
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
            status += $"Survivor Register Report Count:{this.survivorRegisterReports.Count}";
            return status;
        }
    }
    public class SurvivorRegisterReport
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
        public string FIR_SA { get; set; }
        public string FIR_DA { get; set; }
        public string VC { get; set; }
        public string PC { get; set; }
        public string CIT { get; set; }
        public string AliasNames { get; set; }
        public int GenderCode { get; set; }
        public string Gender { get; set; }
        public int FamilyMembers { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public int Children { get; set; }
        public string Address1 { get; set; }
        public int PanchayatCode { get; set; }
        public string Panchayat { get; set; }
        public string Pincode { get; set; }
        public string SHG { get; set; }
        public string Collective { get; set; }
        public string RescuedBy { get; set; }
        public string RescuedState { get; set; }
        public string RescuedDistrict { get; set; }
        public string RescuedCity { get; set; }
        public string RescuePoliceStationName { get; set; }
        public string TypeOfPlace { get; set; }
        public string RescuedPlace { get; set; }
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
