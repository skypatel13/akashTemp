using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class DimensionQuestionDTOAddDB
    {
        public string Question { get; set; }
        public int QuestionUIControlTypeCode { get; set; }
        public int DimensionCode { get; set; }
        public string OptionData { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
