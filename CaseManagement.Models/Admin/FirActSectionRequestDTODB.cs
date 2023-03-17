using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class FirActSectionRequestDTODB
    {
        public int FIRCode { get; set; }
        public string ActSectionData { get; set; }
        public bool IsAddedLater { get; set; }
        public DateTime AddedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}