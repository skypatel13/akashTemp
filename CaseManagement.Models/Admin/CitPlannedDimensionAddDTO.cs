using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class CitPlannedDimensionAddDTO
    {
        public int SurAsmtCode { get; set; }
        public List<SurvivorCitPlanDimDTOList> SurvivorCitPlannedDimDTOAdd { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
