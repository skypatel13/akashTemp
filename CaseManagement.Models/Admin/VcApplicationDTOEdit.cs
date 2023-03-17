﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class VcApplicationDTOEdit
    {
        public int VCCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public int LawyerCode { get; set; }
        public int LegalServiceProviderCode { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationNumber { get; set; }
        public int AmountClaimed { get; set; }
        public IFormFile ReferenceDocument { get; set; }
        public string ReferenceDocumentStoredAs { get; set; }
        public bool IsReferenceDocumentChanged { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}