using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCollectiveMappingDTOList
    {
        public int SurvivorCode { get; set; }
        public int CollectiveCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}