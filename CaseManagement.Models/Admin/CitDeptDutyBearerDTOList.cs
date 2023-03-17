using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class CitDeptDutyBearerDTOList
    {
        public int SurAsmtCode { get; set; }
        public int SurAsmtDimCode { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public int DutyBearerCode { get; set; }
        public string DutyBearer { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
