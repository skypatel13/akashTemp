using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class CityDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public CityDTODetail cityDTODetail { get; set; }

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
            status += $"CityDTODetail :{cityDTODetail}";
            return status;
        }
    }
    public class CityDTODetail
    {
        public int CityCode { get; set; }
        public string City { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int StateCode { get; set; }
        public string State { get; set; }
        public string IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public DateTime? DeletedOn { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
