using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class InvestigationDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<InvestigationDTOList> InvestigationDTOList { get; set; }
        public List<InvestigationDetailChangeDTOList> InvestigationDetailChangeDTOList { get; set; }

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
            status += $"InvestigationDTOList Count:{InvestigationDTOList.Count}";
            return status;
        }
    }

    public class InvestigationDTOList
    {
        public int InvestigationCode { get; set; }
        public int InvestingAgencyCode { get; set; }
        public string InvestingAgency { get; set; }
        public int InvestingAgencyTypeCode { get; set; }
        public string InvestingAgencyType { get; set; }
        public string InvestigatingOfficer { get; set; }
        public int OfficerRankCode { get; set; }
        public string OfficerRank { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public int ResultCode { get; set; }
        public string Result { get; set; }
        public int ReasonCode { get; set; }
        public string Reason { get; set; }
        public DateTime? ChangeDate { get; set; }
        public DateTime? ResultDate { get; set; }
        public int FIRCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public string SourceDestination { get; set; }
        public string PoliceStationName { get; set; }
        public string FIRNumber { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public int StateCode { get; set; }
        public string State { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int RescuedStateCode { get; set; }
        public string RescuedState { get; set; }
        public int RescuedDistrictCode { get; set; }
        public string RescuedDistrict { get; set; }
        public string Block { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public string IsAccepted { get; set; }
        public bool? IsAcceptedValue { get; set; }
        public string AcceptanceReason { get; set; }
        public string IsDeleted { get; set; }
        public  bool IsChargesheetCreated { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class InvestigationDetailChangeDTOList
    {
        public int InvestigationCode { get; set; }
        public int InvestigationAgencyLogCode { get; set; }
        public int InvestingAgencyCode { get; set; }
        public string InvestingAgency { get; set; }
        public int InvestingAgencyTypeCode { get; set; }
        public string InvestingAgencyType { get; set; }
        public string InvestigatingOfficer { get; set; }
        public int OfficerRankCode { get; set; }
        public string OfficerRank { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string Reason { get; set; }
        public int ReasonCode { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int ChangeTypeCode { get; set; }
        public string ChangeType { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}