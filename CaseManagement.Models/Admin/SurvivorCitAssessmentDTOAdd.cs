using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitAssessmentDTOAdd
    {
        public int SurvivorCode { get; set; }
        public int VersionCode { get; set; }
        public DateTime citDate { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
