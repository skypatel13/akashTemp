using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class ActDTOAdd
    {
        public string Act { get; set; }
        public string ActName { get; set; }
        public DateTime? EnforcementDate { get; set; }
        public DateTime? GazetteDate { get; set; }
        public IFormFile GazetteFile { get; set; }
        public string Notes { get; set; }
        public string RefURL { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}