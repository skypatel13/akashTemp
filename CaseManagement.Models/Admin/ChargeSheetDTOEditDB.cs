using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class ChargeSheetDTOEditDB
    {
        public int ChargeSheetCode { get; set; }
        public string ChargeSheetNumber { get; set; }
        public DateTime ChargeSheetDate { get; set; }
        public string TypeOfViolation { get; set; }
        public bool IsChargeSheetCopyChanged { get; set; }
        public string ChargeSheetCopy { get; set; }
        public string ActSectionData { get; set; }
        public string TraffickerData { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
