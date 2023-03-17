using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceProviderDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LegalServiceProviderDTOList> LegalServiceProviderDTOList { get; set; }
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
            status += $"LegalServiceProviderDTOList Count:{this.LegalServiceProviderDTOList.Count}";
            return status;
        }
    }
    public class LegalServiceProviderDTOList
    {
        public int LegalServiceProviderCode { get; set; }
        public string LegalServiceProviderName { get; set; }
        public int LegalServiceTypeCode { get; set; }
        public string LegalServiceTypeId { get; set; }
        public int AuthorityLevelCode { get; set; }
        public string AuthorityLevel { get; set; }
        public string State { get; set; }
        public int StateCode { get; set; }
        public string District { get; set; }
        public int DistrictCode { get; set; }
        public string Notes { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
