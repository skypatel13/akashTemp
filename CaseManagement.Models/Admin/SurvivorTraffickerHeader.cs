using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorTraffickerHeader
    {
        public int TraffickerCode { get; set; }
        public string TraffickerId { get; set; }
        public string TraffickerName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Alias { get; set; }
        public string IdentificationMark { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
