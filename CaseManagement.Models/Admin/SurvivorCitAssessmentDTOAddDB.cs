using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitAssessmentDTOAddDB
    {
        public int SurvivorCode { get; set; }
        public int VersionCode { get; set; }
        public DateTime citDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
