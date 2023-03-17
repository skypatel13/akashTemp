﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DimensionQuestionDTOAdd
    {
        public string Question { get; set; }
        public int QuestionUIControlTypeCode { get; set; }
        public int DimensionCode { get; set; }
        public List<OptionDataMappingListDTO> OptionDataMappingListDTO { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
