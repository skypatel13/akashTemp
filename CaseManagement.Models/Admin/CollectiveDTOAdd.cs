using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class CollectiveDTOAdd
    {
        public int OrganizationId { get; set; }
        public string CollectiveName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
