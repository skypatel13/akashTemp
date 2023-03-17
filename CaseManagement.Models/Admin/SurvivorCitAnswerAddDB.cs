using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitAnswerAddDB
    {
        public int SurAsmtDimQueCode { get; set; }
        public string OptionValue { get; set; }
        public string OptionText { get; set; }
        public string Answer { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
