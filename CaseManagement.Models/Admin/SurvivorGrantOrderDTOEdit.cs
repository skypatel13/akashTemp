using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorGrantOrderDTOEdit
    {
        public int GrantCode { get; set; }
        public int ResultCode { get; set; }
        public DateTime OrderDate { get; set; }
        public int AmountAwarded { get; set; }
        public bool IsOrderDocumentChanged { get; set; }
        public IFormFile OrderDocument { get; set; }
        public bool IsEscalation { get; set; }
        public string EscalationReason { get; set; }
        public int Installments { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
