using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class OrganizationDTOEditDB
    {
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string PartnerId { get; set; }
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