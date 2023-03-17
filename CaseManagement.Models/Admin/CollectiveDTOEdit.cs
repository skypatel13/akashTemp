using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class CollectiveDTOEdit
    {
        public int OrganizationId { get; set; }
        public int CollectiveCode { get; set; }
        public string CollectiveName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}