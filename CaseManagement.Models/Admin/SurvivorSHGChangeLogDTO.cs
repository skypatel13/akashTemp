using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorSHGChangeLogDTOList
    {
        public int SurvivorSHGCode { get; set; }
        public int SurvivorCode { get; set; }
        public string shgId { get; set; }
        public int shgCode { get; set; }
        public string shgName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string IsDeleted { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}