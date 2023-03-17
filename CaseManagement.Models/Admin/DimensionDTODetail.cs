using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class DimensionDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public DimensionDTODetail DimensionDTODetail { get; set; }
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
            status += $"DimensionDTODetail :{DimensionDTODetail}";
            return status;
        }
    }
    public class DimensionDTODetail
    {
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public string Notes { get; set; }
        public string IsObsolete { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public string ObsoleteBy { get; set; }
        public DateTime? ObsoleteOn { get; set; }
        public string ObsoleteByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
