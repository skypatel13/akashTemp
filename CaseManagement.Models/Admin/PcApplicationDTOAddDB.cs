using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class PcApplicationDTOAddDB
    {
        public int SurvivorCode { get; set; }
        public int ReferenceRecordCode { get; set; }
        public string ReferenceRecordType { get; set; }
        public string WhyPCData { get; set; }
        public int ActionCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public int LegalServiceProviderCode { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationNumber { get; set; }
        public int LawyerCode { get; set; }
        public string ReferenceDocument { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}