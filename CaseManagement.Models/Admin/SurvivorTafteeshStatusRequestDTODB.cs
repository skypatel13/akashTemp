using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorTafteeshStatusRequestDTODB
    {
        public int SurvivorCode { get; set; }
        public int TafteeshStatusCode { get; set; }
        public string Notes { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}