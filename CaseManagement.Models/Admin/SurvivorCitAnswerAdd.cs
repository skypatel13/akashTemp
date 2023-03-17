using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitAnswerAdd
    {
        public int SurAsmtDimQueCode { get; set; }
        public string OptionValue { get; set; }
        public string OptionText { get; set; }
        public string Answer { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
