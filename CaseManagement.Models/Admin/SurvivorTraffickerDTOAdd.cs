using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorTraffickerDTOAdd
    {
        public int SurvivorCode { get; set; }
        public List<SurvivorTraffickerMappingDTOList> SurvivorTraffickerMappingDTOList { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}