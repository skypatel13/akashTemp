using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class ActDTOEditDB
    {
        public int ActCode { get; set; }
        public string Act { get; set; }
        public string ActName { get; set; }
        public DateTime? EnforcementDate { get; set; }
        public DateTime? GazetteDate { get; set; }
        public string GazetteFile { get; set; }
        public string RefURL { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}