using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitAssessmentActionDTOEditDB
    {
        public int SurAsmtActCode { get; set; }
        public string Action { get; set; }
        public DateTime TargetedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
