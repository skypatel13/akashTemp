using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorTraffickerRelationDTOAddDB
    {
        public int TraffickerCode { get; set; }
        public int SurvivorCode { get; set; }
        public int RelationCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
