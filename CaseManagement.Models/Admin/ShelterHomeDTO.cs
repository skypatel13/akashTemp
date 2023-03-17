using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class ShelterHomeDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<ShelterHomeDTOList> ShelterHomeDTOList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"ShelterHomeDTOList Count:{ShelterHomeDTOList.Count}";
            return status;
        }
    }

    public class ShelterHomeDTOList
    {
        public int ShelterHomeCode { get; set; }
        public string ShelterHomeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}