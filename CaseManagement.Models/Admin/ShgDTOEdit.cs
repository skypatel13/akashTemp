using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class ShgDTOEdit
    {
        public int ShgCode { get; set; }
        public string ShgName { get; set; }
        public int OrganizationId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}