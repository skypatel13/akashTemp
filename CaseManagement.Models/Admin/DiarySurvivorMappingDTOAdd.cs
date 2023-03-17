using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class DiarySurvivorMappingDTOAdd
    {
        public int SurvivorCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}