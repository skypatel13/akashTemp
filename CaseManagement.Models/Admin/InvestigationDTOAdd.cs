using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class InvestigationDTOAdd
    {
        public int FIRCode { get; set; }
        public int InvestingAgencyCode { get; set; }
        public int InvestingAgencyTypeCode { get; set; }
        public string InvestigatingOfficer { get; set; }
        public int OfficerRankCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}