using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class InvestigationDTOAddDB
    {
        public int FIRCode { get; set; }
        public int InvestingAgencyCode { get; set; }
        public int InvestingAgencyTypeCode { get; set; }
        public string InvestigatingOfficer { get; set; }
        public int OfficerRankCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}