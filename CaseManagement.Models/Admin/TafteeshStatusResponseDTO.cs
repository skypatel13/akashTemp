using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class TafteeshStatusResponseDTO
    {
        public int SurvivorCode { get; set; }
        public int TafteeshStatusLogCode { get; set; }
        public string TafteeshStatusNotes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
