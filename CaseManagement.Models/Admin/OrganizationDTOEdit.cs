using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class OrganizationDTOEdit
    {
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string PartnerId { get; set; }
        public int DistrictCode { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}