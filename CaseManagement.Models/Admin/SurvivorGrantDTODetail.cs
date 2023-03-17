using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorGrantDetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorGrantDTODetail survivorGrantDTODetail { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Survivor Grant Detail :{this.survivorGrantDTODetail}";
            return status;
        }
    }
    public class SurvivorGrantDTODetail
    {
        public int GrantCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string Name { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PurposeCode { get; set; }
        public string Purpose { get; set; }
        public string ApplicationNumber { get; set; }
        public int AmountClaimed { get; set; }
        public string ReferenceDocument { get; set; }
        public string ReferenceDocumentStoredAs { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public int ResultCode { get; set; }
        public string Result { get; set; }
        public DateTime OrderDate { get; set; }
        public int AmountAwarded { get; set; }
        public string OrderDocument { get; set; }
        public string OrderDocumentStoredAs { get; set; }
        public bool IsEscalationValue { get; set; }
        public string IsEscalationText { get; set; }
        public string EscalationReason { get; set; }
        public int Installments { get; set; }
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
