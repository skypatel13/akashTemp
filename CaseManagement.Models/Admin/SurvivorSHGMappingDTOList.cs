using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorSHGMappingDTOList
    {
        public int SurvivorCode { get; set; }
        public int SHGCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}