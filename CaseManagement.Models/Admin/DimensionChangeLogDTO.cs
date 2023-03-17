using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DimensionChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DimensionChangeLogDTOList> DimensionChangeLogDTOList { get; set; }

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
            status += $"DimensionChangeLogDTOList Count:{DimensionChangeLogDTOList.Count}";
            return status;
        }
    }

    public class DimensionChangeLogDTOList
    {
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public string Notes { get; set; }
        public string IsObsolete { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}