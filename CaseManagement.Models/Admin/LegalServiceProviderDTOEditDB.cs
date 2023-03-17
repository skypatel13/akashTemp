using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceProviderDTOEditDB
    {
        public int LegalServiceProviderCode { get; set; }
        public int LegalServiceTypeCode { get; set; }
        public string LegalServiceProviderName { get; set; }
        public int StateCode { get; set; }
        public int DistrictCode { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}