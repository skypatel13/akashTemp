using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class LawyerDTOEditDB
    {
        public int SurvivorLawyerCode { get; set; }
        public int MemberLawyerTypeCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public string LeadingFor { get; set; }
        public bool IsLeading { get; set; }
        public DateTime? LeadingFrom { get; set; }
        public DateTime? LeadingTo { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}