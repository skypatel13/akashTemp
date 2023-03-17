using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class TafteeshStatusLogDTO
    {
        public int SurvivorCode { get; set; }
        public int TafteeshStatusLogCode { get; set; }
        public string TafteeshStatusLog { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string TafteeshStatusNotes { get; set; }
    }
}
