using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class CitDimensionDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public CitDimensionDTODetail CitDimensionDTODetail { get; set; }

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
            status += $"CitDimensionDTODetail :{CitDimensionDTODetail}";
            return status;
        }
    }

    public class CitDimensionDTODetail
    {
        public int VersionDimensionCode { get; set; }
        public int VersionCode { get; set; }
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public int Score { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}