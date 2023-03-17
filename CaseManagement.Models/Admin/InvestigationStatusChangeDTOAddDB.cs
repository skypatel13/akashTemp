using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class InvestigationStatusChangeDTOAddDB
    {
        public int InvestigationCode { get; set; }
        public DateTime? ResultDate { get; set; }
        public int ResultCode { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
