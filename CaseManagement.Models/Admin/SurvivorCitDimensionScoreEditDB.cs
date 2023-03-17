using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitDimensionScoreEditDB
    {
        public int SurAsmtDimCode { get; set; }
        public int Score { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
