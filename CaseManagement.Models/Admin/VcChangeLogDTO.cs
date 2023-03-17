using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class VcChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<VcChangeLogDTOList> VcChangeLogDTOList { get; set; }

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
            status += $"VcChangeLogDTOList Count:{VcChangeLogDTOList.Count}";
            return status;
        }
    }

    public class VcChangeLogDTOList
    {
        public int VCCode { get; set; }
        public int SurvivorCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public string SourceDestination { get; set; }
        public int LawyerCode { get; set; }
        public string LawyerId { get; set; }
        public string AppliedAt { get; set; }
        public string AppliedAtFullName { get; set; }
        public int LegalServiceProviderCode { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationNumber { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public int AmountClaimed { get; set; }
        public int ResultCode { get; set; }
        public string Result { get; set; }
        public DateTime? OrderDate { get; set; }
        public int AmountAwarded { get; set; }
        public string IsAmountReceived { get; set; }
        public string AmountReceivedBank { get; set; }
        public DateTime? AmountReceivedDate { get; set; }
        public int AmountDifference { get; set; }
        public string IsEscalationRequired { get; set; }
        public string EscalationReason { get; set; }
        public string IsEscalation { get; set; }
        public int ParentVCCode { get; set; }
        public int ParentRecordCode { get; set; }
        public string Notes { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}