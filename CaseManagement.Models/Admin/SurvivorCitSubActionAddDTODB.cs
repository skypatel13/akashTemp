using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitSubActionAddDTODB
    {
        public int SurAsmtActCode { get; set; }
        public string Activity { get; set; }
        public int DepartmentCode { get; set; }
        public int DutyBearerCode { get; set; }
        public DateTime TargetedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
