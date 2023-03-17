using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class ChargeSheetDTOAddDB
    {
        public int InvestigationCode { get; set; }
        public int SurvivorCode { get; set; }
        public string ChargeSheetNumber { get; set; }
        public DateTime ChargeSheetDate { get; set; }
        public string TypeOfViolation { get; set; }
        public string ChargeSheetCopy { get; set; }
        public string ActSectionData { get; set; }
        public string TraffickerData { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
