using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitDimensionQuestionOption
    {
        public int SurAsmtDimQueCode { get; set; }
        public string OptionValue { get; set; }
        public string OptionText { get; set; }
        public Boolean IsSelected { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
