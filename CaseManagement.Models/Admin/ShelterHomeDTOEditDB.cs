using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class ShelterHomeDTOEditDB
    {
        public int ShelterHomeCode { get; set; }
        public string ShelterHomeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int DistrictCode { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}