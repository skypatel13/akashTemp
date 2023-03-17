using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorPoliceStationSourceDestinationDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorPoliceStationSourceDestinationDTOList> SurvivorPoliceStationSourceDestinationDTOList { get; set; }

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
            status += $"SurvivorPoliceStationSourceDestinationDTOList Count:{SurvivorPoliceStationSourceDestinationDTOList.Count}";
            return status;
        }
    }

    public class SurvivorPoliceStationSourceDestinationDTOList
    {
        public int SurvivorCode { get; set; }
        public string SourceDestination { get; set; }
        public int SourceDestinationCode { get; set; }
        public int PoliceStationCode { get; set; }
        public string PoliceStationName { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}