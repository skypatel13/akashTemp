using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceTypeDTOEditDB
    {
        public int LegalServiceTypeCode { get; set; }
        public string LegalServiceTypeId { get; set; }
        public string LegalServiceTypeName { get; set; }
        public int AuthorityLevelCode { get; set; }
        public string ProgramAxisData { get; set; }
        public Boolean IsCourt { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}