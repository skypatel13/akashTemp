using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class CitDimensionDTOAddDB
    {
        public int VersionCode { get; set; }
        public string DimensionData { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}