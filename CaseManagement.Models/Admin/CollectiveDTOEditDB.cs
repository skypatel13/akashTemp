using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class CollectiveDTOEditDB
    {
        public int CollectiveCode { get; set; }
        public int OrganizationId { get; set; }
        public string CollectiveName { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}