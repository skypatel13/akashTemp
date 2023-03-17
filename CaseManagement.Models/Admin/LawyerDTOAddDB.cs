using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class LawyerDTOAddDB
    {
        public int SurvivorCode { get; set; }
        public int MemberLawyerTypeCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public string LeadingFor { get; set; }
        public bool IsLeading { get; set; }
        public Nullable<DateTime> LeadingFrom { get; set; }
        public Nullable<DateTime> LeadingTo { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}