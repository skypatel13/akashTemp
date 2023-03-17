using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitDimensionScoreEdit
    {
        public int SurAsmtDimCode { get; set; }
        public int Score { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
