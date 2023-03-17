using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class PartnerDTOEdit
    {
        public int PartnerCode { get; set; }
        public string PartnerName { get; set; }
        public string Notes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
