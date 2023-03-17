using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceProviderDTOAddDB
    {
        public int LegalServiceTypeCode { get; set; }
        public string LegalServiceProviderName { get; set; }
        public int StateCode { get; set; }
        public int DistrictCode { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}