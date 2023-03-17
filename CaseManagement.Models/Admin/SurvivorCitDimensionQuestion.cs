using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitDimensionQuestion
    {
        public int SurAsmtDimQueCode { get; set; }
        public int SurAsmtDimCode { get; set; }
        public int VersionDimensionQuestionCode { get; set; }
        public string Question { get; set; }
        public int QuestionUIControlTypeCode { get; set; }
        public string QuestionUIControlType { get; set; }
        public string Answer { get; set; }
        public Boolean IsActionAdded { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
