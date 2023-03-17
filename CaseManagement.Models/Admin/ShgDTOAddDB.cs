using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class ShgDTOAddDB
    {
        public string ShgName { get; set; }
        public int OrganizationId { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}