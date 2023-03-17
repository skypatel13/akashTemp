using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class TafteeshStatusResponseDTODB
    {
        public int SurvivorCode { get; set; }
        public int TafteeshStatusLogCode { get; set; }
        public string TafteeshStatusNotes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
