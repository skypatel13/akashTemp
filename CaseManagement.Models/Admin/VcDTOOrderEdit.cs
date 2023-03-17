using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class VcDTOOrderEdit
    {
        public int VCCode { get; set; }
        public int ResultCode { get; set; }
        public DateTime? OrderDate { get; set; }
        public IFormFile OrderDocument { get; set; }
        public int? AmountAwarded { get; set; }
        public bool IsOrderDocumentChanged { get; set; }
        public bool IsEscalationRequired { get; set; }
        public string EscalationReason { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}