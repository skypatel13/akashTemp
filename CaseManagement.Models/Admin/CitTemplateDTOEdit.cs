using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class CitTemplateDTOEdit
    {
        public int VersionCode { get; set; }
        public string VersionName { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}