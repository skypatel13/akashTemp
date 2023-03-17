using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceTypeDTOEdit
    {
        public int LegalServiceTypeCode { get; set; }
        public string LegalServiceTypeId { get; set; }
        public string LegalServiceTypeName { get; set; }
        public int AuthorityLevelCode { get; set; }
        public List<LegalServiceTypeProgramAxis> ProgramAxisData { get; set; }
        public Boolean IsCourt { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}