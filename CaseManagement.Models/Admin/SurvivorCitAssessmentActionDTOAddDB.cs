using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public  class SurvivorCitAssessmentActionDTOAddDB
    {
        public int SurAsmtDimCode { get; set; }
        public string Action { get; set; }
        public DateTime TargetedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
