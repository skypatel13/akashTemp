using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceProviderDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public LegalServiceProviderDTODetail LegalServiceProviderDTODetail { get; set; }

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
            status += $"LegalServiceProviderDTODetail :{this.LegalServiceProviderDTODetail}";
            return status;
        }
    }

    public class LegalServiceProviderDTODetail
    {
        public int LegalServiceProviderCode { get; set; }
        public string LegalServiceProviderName { get; set; }
        public string LegalServiceTypeId { get; set; }
        public int LegalServiceTypeCode { get; set; }
        public int AuthorityLevelCode { get; set; }
        public string AuthorityLevel { get; set; }
        public string State { get; set; }
        public int StateCode { get; set; }
        public string District { get; set; }
        public int DistrictCode { get; set; }
        public string Notes { get; set; }
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