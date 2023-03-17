using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class CitStatusLogDTO
    {
        public int SurAsmtCode { get; set; }
        public int ApprovalStatusCode { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ApprovalStatusNotes { get; set; }
    }
}
