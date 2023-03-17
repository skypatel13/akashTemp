using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class RoleDTOAdd
    {
        public string Role { get; set; }
        public string Purpose { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}