using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorGrantOrderEditDB
    {
        public int GrantCode { get; set; }
        public int ResultCode { get; set; }
        public DateTime OrderDate { get; set; }
        public int AmountAwarded { get; set; }
        public bool IsOrderDocumentChanged { get; set; }
        public string OrderDocument { get; set; }
        public bool IsEscalation { get; set; }
        public string EscalationReason { get; set; }
        public int Installments { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
