using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class PartnerDTOEditDB
    {
        public int PartnerCode { get; set; }
        public string PartnerName { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}