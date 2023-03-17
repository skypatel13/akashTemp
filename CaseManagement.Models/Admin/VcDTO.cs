using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class VcDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public VcDTOAmount vcDTOAmount { get; set; }
        public List<VcDTOList> VcDTOList { get; set; }

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
            status += $"VC Amount Claimed:{vcDTOAmount}";
            status += $"VcDTOList Count:{VcDTOList.Count}";
            return status;
        }
    }
    public class VcDTOAmount
    {
        public int SurvivorCode { get; set; }
        public int? AmountClaimed { get; set; }
        public int? TotalAmountAwarded { get; set; }
        public int? TotalAmountDifference { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class VcDTOList
    {
        public int VCCode { get; set; }
        public int SurvivorCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public string SourceDestination { get; set; }
        public int LawyerCode { get; set; }
        public string LawyerId { get; set; }
        public string LawyerName { get; set; }
        public string AppliedAt { get; set; }
        public string AppliedAtFullName { get; set; }
        public int LegalServiceProviderCode { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationNumber { get; set; }
        public int AmountClaimed { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public bool IsEscalationValue { get; set; }
        public string IsEscalationText { get; set; }
        public int ResultCode { get; set; }
        public string Result { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderDocument { get; set; }
        public string OrderDocumentStoredAs { get; set; }
        public int AmountAwarded { get; set; }
        public bool IsAmountReceivedValue { get; set; }
        public string IsAmountReceivedText { get; set; }
        public int AmountReceivedBank { get; set; }
        public DateTime? AmountReceivedDate { get; set; }
        public int AmountDifference { get; set; }
        public int EscalationCount { get; set; }
        public bool IsEscalationRequiredValue { get; set; }
        public string IsEscalationRequiredText { get; set; }
        public string EscalationReason { get; set; }
        public string IsDeleted { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}