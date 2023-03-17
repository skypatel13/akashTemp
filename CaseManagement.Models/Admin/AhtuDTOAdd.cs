using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class AhtuDTOAdd
    {
        public string AhtuName { get; set; }
        public int DistrictCode { get; set; }
        public int StateCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}