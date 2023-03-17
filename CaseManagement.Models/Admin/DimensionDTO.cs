using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DimensionDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DimensionDTOList> DimensionDTOList { get; set; }

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
            status += $"DimensionDTOList Count:{DimensionDTOList.Count}";
            return status;
        }
    }

    public class DimensionDTOList
    {
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public string Notes { get; set; }
        public string IsObsolete { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}