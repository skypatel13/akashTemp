using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorTafteeshStatusRequestDTO
    {
        public int SurvivorCode { get; set; }
        public int TafteeshStatusCode { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}