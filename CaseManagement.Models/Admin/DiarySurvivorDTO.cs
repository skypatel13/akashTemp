using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DiarySurvivorDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DiarySurvivorDTOList> DiarySurvivorDTOList { get; set; }

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
            status += $"DiarySurvivorDTOList Count:{DiarySurvivorDTOList?.Count}";
            return status;
        }
    }

    public class DiarySurvivorDTOList
    {
        public int MemberCode { get; set; }
        public string MemberName { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string PoliceStationName { get; set; }
        public string AliasNames { get; set; }
        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}