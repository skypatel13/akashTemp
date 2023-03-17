using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorProfileApproveRequestDTODB
    {
        public int SurvivorCode { get; set; }
        public int SurvivorTypeCode { get; set; }
        public string Notes { get; set; }
        public string ProfileApprovedBy { get; set; }
        public string ProfileApprovedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
