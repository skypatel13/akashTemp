using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class InvestigationAgencyChangeDTOAdd
    {
        public int InvestigationCode { get; set; }
        public int InvestingAgencyCode { get; set; }
        public int InvestingAgencyTypeCode { get; set; }
        public string InvestigatingOfficer { get; set; }
        public int OfficerRankCode { get; set; }
        public DateTime? ChangeDate { get; set; }
        public int ReasonCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
