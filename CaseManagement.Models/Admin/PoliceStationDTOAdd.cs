using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class PoliceStationDTOAdd
    {
        public string PoliceStationName { get; set; }
        public string Address { get; set; }
        public int DistrictCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}