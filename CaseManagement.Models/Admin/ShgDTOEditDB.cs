using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class ShgDTOEditDB
    {
        public int ShgCode { get; set; }
        public string ShgName { get; set; }
        public int OrganizationId { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}