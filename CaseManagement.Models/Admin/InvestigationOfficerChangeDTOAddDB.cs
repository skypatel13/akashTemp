using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class InvestigationOfficerChangeDTOAddDB
    {
        public int InvestigationCode { get; set; }
        public string InvestigatingOfficer { get; set; }
        public int OfficerRankCode { get; set; }
        public DateTime? ChangeDate { get; set; }
        public int ReasonCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
