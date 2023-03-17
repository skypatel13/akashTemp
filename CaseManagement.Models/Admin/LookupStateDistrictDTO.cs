using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class LookupStateDistrictDTOListResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LookupStateDistrictDTOList> LookupStateDistrictDTOList { get; set; }
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
            status += $"LookupStateDistrictDTOList Count:{this.LookupStateDistrictDTOList.Count}";
            return status;
        }
    }
    public class LookupStateDistrictDTOList
    {
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string StateId { get; set; }
        public int StateCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
