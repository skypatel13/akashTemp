using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class InvestigationStatusChangeDTOAdd
    {
        public int InvestigationCode { get; set; }
        public DateTime? ResultDate{ get; set; }
        public int ResultCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
