using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class DistrictDTOAddDB
    {
        public string District { get; set; }
        public string StateId { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
