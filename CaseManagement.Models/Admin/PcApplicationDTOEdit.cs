using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class PcApplicationDTOEdit
    {
        public int PCCode { get; set; }
        public int ReferenceRecordCode { get; set; }
        public string ReferenceRecordType { get; set; }
        public string PCWhyMappingDTOAdd { get; set; }
        public int ActionCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public int LegalServiceProviderCode { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationNumber { get; set; }
        public int LawyerCode { get; set; }
        public bool IsReferenceDocumentChanged { get; set; }
        public IFormFile ReferenceDocument { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}