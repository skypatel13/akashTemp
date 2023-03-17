using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class CitDeptDutyBearerAddDTO
    {
        public int SurAsmtDimCode { get; set; }
        public List<CitDeptDutyBearerMappingDTO> CitDeptDutyBearerMappingData { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
    public class CitDeptDutyBearerMappingDTO 
    {
        public int DepartmentCode { get; set; }
        public int DutyBearerCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
