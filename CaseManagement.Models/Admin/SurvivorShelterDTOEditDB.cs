﻿using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorShelterDTOEditDB
    {
        public int SurvivorShelterHomeCode { get; set; }
        public int ShelterHomeCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
