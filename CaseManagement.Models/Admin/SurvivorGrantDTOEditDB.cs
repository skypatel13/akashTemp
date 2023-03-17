using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorGrantDTOEditDB
    {
        public int GrantCode { get; set; }
        public string Name { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PurposeCode { get; set; }
        public string ApplicationNumber { get; set; }
        public int AmountClaimed { get; set; }
        public bool IsReferenceDocumentChanged { get; set; }
        public string ReferenceDocument { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
