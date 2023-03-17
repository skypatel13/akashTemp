using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class DimensionDTOEditDB
    {
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}