﻿using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class DocumentTypeDTOEdit
    {
        public int DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public bool IsRequiredForSurvivor { get; set; }
        public bool IsSurvivorSpecific { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}