using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class VcDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public VcDTODetail VcDTODetail { get; set; }

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
            status += $"VcDTODetail :{VcDTODetail}";
            return status;
        }
    }

    public class VcDTODetail
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
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public int AmountClaimed { get; set; }
        public bool IsVideoConferencingValue { get; set; }
        public string IsVideoConferencingText { get; set; }
        public string ReferenceDocument { get; set; }
        public string ReferenceDocumentStoredAs { get; set; }
        public int? ResultCode { get; set; }
        public string Result { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderDocument { get; set; }
        public string OrderDocumentStoredAs { get; set; }
        public int? AmountAwarded { get; set; }
        public bool IsAmountReceivedValue { get; set; }
        public string IsAmountReceivedText { get; set; }
        public int? AmountReceivedBank { get; set; }
        public DateTime? AmountReceivedDate { get; set; }
        public int? AmountDifference { get; set; }
        public int EscalationCount { get; set; }
        public bool IsEscalationRequiredValue { get; set; }
        public string IsEscalationRequiredText { get; set; }
        public string EscalationReason { get; set; }
        public bool IsEscalationValue { get; set; }
        public string IsEscalationText { get; set; }
        public int ParentVCCode { get; set; }
        public int ParentRecordCode { get; set; }
        public string Notes { get; set; }
        public DateTime? ConcludedOn { get; set; }
        public DateTime? ConcludedDate { get; set; }
        public string ConcludedReason { get; set; }
        public int ConcludedReasonCode { get; set; }
        public string ConcludedBy { get; set; }
        public string ConcludedByIpAddress { get; set; }
        public string ConcludedNotes { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}