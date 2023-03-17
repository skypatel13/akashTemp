using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class VCConcludeDTOAdd
    {
        public int vcCode { get; set; }
        public DateTime ConcludedDate { get; set; }
        public int ConcludedReasonCode { get; set; }
        public string concludedNotes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
