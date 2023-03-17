using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorProfileApproveRequestDTO
    {
        public int SurvivorCode { get; set; }
        public int SurvivorTypeCode { get; set; }
        public string Notes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}