using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class PoliceStationDTOAddDB
    {
        public string PoliceStationName { get; set; }
        public string Address { get; set; }
        public int DistrictCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}