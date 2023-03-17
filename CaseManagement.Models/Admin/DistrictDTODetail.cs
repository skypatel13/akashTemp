using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class DistrictDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public DistrictDTODetail DistrictDTODetail { get; set; }

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
            status += $"DistrictDTO Detail:{this.DistrictDTODetail}";
            return status;
        }
    }

    public class DistrictDTODetail
    {
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public string StateId { get; set; }
        public int StateCode { get; set; }
        public string State { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
