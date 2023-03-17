using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class CitDimensionChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<CitDimensionChangeLogDTOList> CitDimensionChangeLogDTOList { get; set; }

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
            status += $"CitDimensionChangeLogDTOList Count:{CitDimensionChangeLogDTOList.Count}";
            return status;
        }
    }

    public class CitDimensionChangeLogDTOList
    {
        public int VersionDimensionCode { get; set; }
        public int VersionCode { get; set; }
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public int Score { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}