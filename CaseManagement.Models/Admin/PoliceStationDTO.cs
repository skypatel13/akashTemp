using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class PoliceStationDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<PoliceStationDTOList> PoliceStationDTOList { get; set; }
        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"PoliceStationDTOList Count:{this.PoliceStationDTOList.Count}";
            return status;
        }
    }
    public class PoliceStationDTOList
    {
        public int PoliceStationCode { get; set; }
        public string PoliceStationName { get; set; }
        public string Address { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
