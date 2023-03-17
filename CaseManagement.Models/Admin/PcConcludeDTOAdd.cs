using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class PcConcludeDTOAdd
    {
        public int pcCode { get; set; }
        public DateTime ConcludedDate { get; set; }
        public int ConcludedReasonCode { get; set; }
        public string ConcludedNotes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}