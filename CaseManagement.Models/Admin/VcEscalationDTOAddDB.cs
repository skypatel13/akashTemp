﻿using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class VcEscalationDTOAddDB
    {
        public int VCCode { get; set; }
        public int LawyerCode { get; set; }
        public int LegalServiceProviderCode { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationNumber { get; set; }
        public int AmountClaimed { get; set; }
        public string ReferenceDocument { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}