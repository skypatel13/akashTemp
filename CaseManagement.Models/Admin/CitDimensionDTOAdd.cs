using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class CitDimensionDTOAdd
    {
        public int VersionCode { get; set; }
        public List<CitDimensionMappingDTOList> CitDimensionMappingDTOList { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class CitDimensionMappingDTOList
    {
        public int DimensionCode { get; set; }
        public int VersionCode { get; set; }
        public int Score { get; set; }
    }
}