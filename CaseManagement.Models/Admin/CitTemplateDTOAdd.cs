using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class CitTemplateDTOAdd
    {
        public string VersionName { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}