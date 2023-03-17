using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class VcApplicationDTOEditDB
    {
        public int VCCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public int LawyerCode { get; set; }
        public int LegalServiceProviderCode { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationNumber { get; set; }
        public int AmountClaimed { get; set; }
        public string ReferenceDocument { get; set; }
        public bool IsReferenceDocumentChanged { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}