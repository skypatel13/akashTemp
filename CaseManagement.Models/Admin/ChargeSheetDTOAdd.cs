using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class ChargeSheetDTOAdd
    {
        public int InvestigationCode { get; set; }
        public int SurvivorCode { get; set; }
        public string ChargeSheetNumber { get; set; }
        public DateTime ChargeSheetDate { get; set; }
        public string TypeOfViolation { get; set; }
        public IFormFile ChargeSheetCopy { get; set; }
        public string ChargeSheetActSectionMappingDTOList { get; set; }
        public string ChargeSheetAccusedMappingDTOList { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
