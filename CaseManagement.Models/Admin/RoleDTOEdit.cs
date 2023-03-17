using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class RoleDTOEdit
    {
        public string RoleId { get; set; }
        public string Purpose { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}