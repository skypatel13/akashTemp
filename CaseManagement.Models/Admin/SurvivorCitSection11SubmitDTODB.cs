using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitSection11SubmitDTODB
    {
        public int SurAsmtCode { get; set; }
        public bool IsParentPresent { get; set; }
        public string RolePlay { get; set; }
        public string CareGiverOpinion { get; set; }
        public string CareGiverFeedback { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
