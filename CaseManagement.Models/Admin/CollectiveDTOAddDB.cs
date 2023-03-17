using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class CollectiveDTOAddDB
    {
        public int OrganizationId { get; set; }
        public string CollectiveName { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}