using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class InvestigationAcceptanceDTOUpdate
    {
        public int InvestigationCode { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public bool IsAccepted { get; set; }
        public List<InvestigationAcceptanceMappingDTOAdd> InvestigationAcceptanceMappingDTOAdd { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
