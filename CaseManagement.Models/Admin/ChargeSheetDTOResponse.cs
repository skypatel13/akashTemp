using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace CaseManagement.Models.Admin
{
    public class ChargeSheetDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<ChargeSheetDTOList> ChargeSheetDTOList { get; set; }
        public List<ChargeSheetSectionDTOList> ChargeSheetSectionDTOList { get; set; }
        public List<ChargeSheetAccuseDTOList> ChargeSheetAccuseDTOList { get; set; }
        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"ChargeSheetDTOList Count:{ChargeSheetDTOList.Count}";
            status += $"ChargeSheetSectionDTOList Count:{ChargeSheetSectionDTOList.Count}";
            status += $"ChargeSheetAccuseDTOList Count:{ChargeSheetAccuseDTOList.Count}";
            return status;
        }
    }
    public class ChargeSheetDTOList
    {
        public string SourceDestination { get; set; }
        public string FirNumber { get; set; }
        public DateTime FirDate { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string InvestingAgencyType { get; set; }
        public string InvestingAgency { get; set; }
        public string InvestigatingOfficer { get; set; }
        public string OfficerRank { get; set; }
        public int ChargeSheetCode { get; set; }
        public int InvestigationCode { get; set; }
        public string ChargeSheetNumber { get; set; }
        public DateTime ChargeSheetDate { get; set; }
        public string TypeOfViolation { get; set; }
        public string Sections { get; set; }
        public string Traffickers { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class ChargeSheetSectionDTOList
    {
        public int ActCode { get; set; }
        public string Act { get; set; }
        public string ActName { get; set; }
        public int ActSectionCode { get; set; }
        public string Section { get; set; }
        public string SectionTitle { get; set; }
        public string IsForMinor { get; set; }
        public int ChargesheetCode { get; set; }
        public string IsAddedLater { get; set; }
        public DateTime AddedOn { get; set; }
        public bool IsFIRSection { get; set; }
        public string IsFIRSectionText { get; set; }
        public bool IsSelected { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class ChargeSheetAccuseDTOList
    {
        public int ChargesheetAccusedCode { get; set; }
        public int FIRAccusedCode { get; set; }
        public int ChargesheetCode { get; set; }
        public string TraffickerId { get; set; }
        public int TraffickerCode { get; set; }
        public string TraffickerName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public int GenderCode { get; set; }
        public string IdentificationMark { get; set; }
        public int Age { get; set; }
        public string IsDeleted { get; set; }
        public bool IsFIRAccused { get; set; }
        public string IsFIRAccusedText { get; set; }
        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
