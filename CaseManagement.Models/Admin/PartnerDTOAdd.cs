using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class PartnerDTOAdd
    {
        public string PartnerName { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}