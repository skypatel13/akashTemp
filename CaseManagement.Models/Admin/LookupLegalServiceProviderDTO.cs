using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class LookupLegalServiceProviderDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LookupLegalServiceTypeDTOList> LookupLegalServiceTypeDTOList { get; set; }
        public List<LookupLegalServiceProviderDTOList> LookupLegalServiceProviderDTOList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!this.DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"Lookup LookupLegalServiceTypeDTOList Count:{this.LookupLegalServiceTypeDTOList.Count}";
            status += $"Lookup LegalServiceProviderDTOList Count:{this.LookupLegalServiceProviderDTOList.Count}";
            return status;
        }
    }

    public class LookupLegalServiceTypeDTOList
    {
        public string LegalServiceTypeId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class LookupLegalServiceProviderDTOList
    {
        public int LegalServiceProviderCode { get; set; }
        public string LegalServiceProviderName { get; set; }
        public string LegalServiceTypeId { get; set; }
        public int SourceDestinationCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}