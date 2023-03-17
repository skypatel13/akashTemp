using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorTraffickerRelationDTOAdd
    {
        public int TraffickerCode { get; set; }
        public int SurvivorCode { get; set; }
        public int RelationCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
