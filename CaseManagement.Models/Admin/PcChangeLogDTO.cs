using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class PcChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<PcChangeLogDTOList> PcChangeLogDTOList { get; set; }

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
            status += $"PcChangeLogDTOList Count:{PcChangeLogDTOList.Count}";
            return status;
        }
    }

    public class PcChangeLogDTOList
    {
        public int PCCode { get; set; }
        public int SurvivorCode { get; set; }
        public int ReferenceRecordCode { get; set; }
        public string ReferenceRecordType { get; set; }
        public int WhyPCCode { get; set; }
        public string WhyPC { get; set; }
        public string Action { get; set; }
        public int SourceDestinationCode { get; set; }
        public string SourceDestination { get; set; }
        public string AppliedAt { get; set; }
        public string AppliedAtFullName { get; set; }
        public int LegalServiceProviderCode { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationNumber { get; set; }
        public int LawyerCode { get; set; }
        public string LawyerId { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public int ResultCode { get; set; }
        public string Result { get; set; }
        public DateTime ResultDate { get; set; }
        public DateTime OrderReceivedDate { get; set; }
        public DateTime OrderSubmittedDate { get; set; }
        public bool IsEscalationRequiredValue { get; set; }
        public string IsEscalationRequiredText { get; set; }
        public bool IsEscalationValue { get; set; }
        public string IsEscalationText { get; set; }
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