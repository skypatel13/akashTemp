using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitAssessmentActionDTOAdd
    {
        public int SurAsmtDimCode { get; set; }
        public string Action { get; set; }
        public DateTime TargetedDate { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
