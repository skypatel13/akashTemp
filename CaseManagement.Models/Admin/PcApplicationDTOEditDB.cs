using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class PcApplicationDTOEditDB
    {
        public int PCCode { get; set; }
        public int ReferenceRecordCode { get; set; }
        public string ReferenceRecordType { get; set; }
        public string WhyPCData { get; set; }
        public int ActionCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public int LegalServiceProviderCode { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationNumber { get; set; }
        public int LawyerCode { get; set; }
        public bool IsReferenceDocumentChanged { get; set; }
        public string ReferenceDocument { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}