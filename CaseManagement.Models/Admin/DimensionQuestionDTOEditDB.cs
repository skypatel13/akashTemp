using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class DimensionQuestionDTOEditDB
    {
        public int DimensionQuestionCode { get; set; }
        public string Question { get; set; }
        public int QuestionUIControlTypeCode { get; set; }
        public int DimensionCode { get; set; }
        public string OptionData { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
