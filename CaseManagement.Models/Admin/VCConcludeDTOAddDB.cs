using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class VCConcludeDTOAddDB
    {
        public int vcCode { get; set; }
        public DateTime ConcludedDate { get; set; }
        public int ConcludedReasonCode { get; set; }
        public string concludedNotes { get; set; }
        public string concludedBy { get; set; }
        public string concludedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
