using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class PCWhyMappingDTOAdd
    {
        public int WhyPcCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}