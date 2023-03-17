using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceTypeDTOAddDB
    {
        public string LegalServiceTypeId { get; set; }
        public string LegalServiceTypeName { get; set; }
        public int AuthorityLevelCode { get; set; }
        public string ProgramAxisData { get; set; }
        public Boolean IsCourt { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}