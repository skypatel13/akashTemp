using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class CitStatusResponseDTO
    {
        public int SurAsmtCode { get; set; }
        public int ApprovalStatusCode { get; set; }
        public string ApprovalStatusNotes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
