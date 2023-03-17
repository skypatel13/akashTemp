using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class InvestigationAcceptanceDTOUpdateDB
    {
        public int InvestigationCode { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public bool IsAccepted { get; set; }
        public string AcceptanceReasonData { get; set; }
        public string AcceptanceBy { get; set; }
        public string AcceptanceByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
