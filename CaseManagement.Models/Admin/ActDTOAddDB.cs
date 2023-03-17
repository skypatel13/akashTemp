using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class ActDTOAddDB
    {
        public string Act { get; set; }
        public string ActName { get; set; }
        public DateTime? EnforcementDate { get; set; }
        public DateTime? GazetteDate { get; set; }
        public string GazetteFile { get; set; }
        public string Notes { get; set; }
        public string RefURL { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}