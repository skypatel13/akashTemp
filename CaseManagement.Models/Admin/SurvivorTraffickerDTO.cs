using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorTraffickerDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorTraffickerDTOList> SurvivorTraffickerDTOList { get; set; }
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
            status += $"SurvivorTraffickerDTOList Count:{SurvivorTraffickerDTOList.Count}";
            return status;
        }
    }

    public class SurvivorTraffickerDTOList
    {
        public int TraffickerCode { get; set; }
        public string TraffickerId { get; set; }
        public int SourceDestinationCode { get; set; }
        public string SourceDestination { get; set; }
        public string TraffickerName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Alias { get; set; }
        public string IdentificationMark { get; set; }
        public int FirCode { get; set; }
        public string FirNumber { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string Relation { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}