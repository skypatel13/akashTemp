using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorGrantDTOAdd
    {
        public int SurvivorCode { get; set; }
        public string Name { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PurposeCode { get; set; }
        public string ApplicationNumber { get; set; }
        public int AmountClaimed { get; set; }
        public IFormFile ReferenceDocument { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
