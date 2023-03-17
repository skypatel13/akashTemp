using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitAssessmentSubmitDTODB
    {
        public int SurAsmtCode { get; set; }
        public int Score { get; set; }
        public string StrengthResource { get; set; }
        public string WorryStatement { get; set; }
        public string GoalStatement { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
