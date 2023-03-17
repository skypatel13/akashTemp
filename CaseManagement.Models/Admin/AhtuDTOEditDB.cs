using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class AhtuDTOEditDB
    {
        public int AHTUCode { get; set; }
        public string AHTUName { get; set; }
        public int DistrictCode { get; set; }
        public int StateCode { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}