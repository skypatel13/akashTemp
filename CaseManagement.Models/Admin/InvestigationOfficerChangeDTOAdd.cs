using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class InvestigationOfficerChangeDTOAdd
    {
        public int InvestigationCode { get; set; }
        public string InvestigatingOfficer { get; set; }
        public int OfficerRankCode { get; set; }
        public int ReasonCode { get; set; }
        public DateTime? ChangeDate { get; set; }
      
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
