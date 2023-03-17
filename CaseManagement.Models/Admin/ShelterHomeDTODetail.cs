using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class ShelterHomeDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public ShelterHomeDTODetail ShelterHomeDTODetail { get; set; }

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
            status += $"ShelterHomeDTODetail :{ShelterHomeDTODetail}";
            return status;
        }
    }

    public class ShelterHomeDTODetail
    {
        public int ShelterHomeCode { get; set; }
        public string ShelterHomeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string StateId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
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