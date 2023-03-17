using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorSHGDTOList
    {
        public int SurvivorSHGCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SHGId { get; set; }
        public int SHGCode { get; set; }
        public string SHGName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}