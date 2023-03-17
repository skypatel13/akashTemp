using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class CitDimensionDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<CitDimensionDTOList> CitDimensionDTOList { get; set; }

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
            status += $"CitDimensionDTOList Count:{CitDimensionDTOList.Count}";
            return status;
        }
    }

    public class CitDimensionDTOList
    {
        public int VersionCode { get; set; }
        public string VersionName { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public int VersionDimensionCode { get; set; }
        public int Score { get; set; }
        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}