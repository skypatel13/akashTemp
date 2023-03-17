using CaseManagement.Models.Common;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class LookupRescueLocationResponseDTO
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LookupStateDTOList> LookupStateDTOList { get; set; }
        public List<LookupStateDistrictDTOList> LookupStateDistrictDTOList { get; set; }
        public List<LookupCityDTOList> LookupCityDTOList { get; set; }
        public List<LookupPoliceStationDTOList> lookupPoliceStationDTOLists { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!this.DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"StateDTO List Count:{this.LookupStateDTOList.Count}";
            status += $"District List Count:{this.LookupStateDistrictDTOList.Count}";
            status += $"City List Count:{this.LookupCityDTOList.Count}";
            status += $"Police Station List Count:{this.lookupPoliceStationDTOLists.Count}";
            return status;
        }
    }

    public class LookupCityDTOList
    {
        public string State { get; set; }
        public string StateId { get; set; }
        public string StateCode { get; set; }
        public string DistrictCode { get; set; }
        public string District { get; set; }
        public int CityCode { get; set; }
        public string City { get; set; }
    }
}