using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class DistrictDTOEdit
    {
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int StateCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}