using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorGrantDTOAddDB
    {
        public int SurvivorCode { get; set; }
        public string Name { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PurposeCode { get; set; }
        public string ApplicationNumber { get; set; }
        public int AmountClaimed { get; set; }
        public string ReferenceDocument { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
