using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class LookupLegalServiceTypeDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LookupLegalServiceType> lookupLegalServiceTypes { get; set; }

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
            status += $"Lookup Legal ServiceType Count:{this.lookupLegalServiceTypes.Count}";
            return status;
        }
    }
    public class LookupLegalServiceType
    {
        public int LegalServiceTypeCode { get; set; }
        public string LegalServiceTypeId { get; set; }
        public string LegalServiceTypeName { get; set; }
        public int AuthorityLevelCode { get; set; }
        public string AuthorityLevel { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
