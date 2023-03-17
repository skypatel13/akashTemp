using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class CitDimensionQuestionDTOAdd
    {
        public int VersionDimensionCode { get; set; }
        public List<CitDimensionQuestionMappingDTOList> CitDimensionQuestionMappingDTOList { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class CitDimensionQuestionMappingDTOList
    {
        public int DimensionQuestionCode { get; set; }
        public int VersionDimensionCode { get; set; }
    }
}