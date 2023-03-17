using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class CitTemplateDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<CitTemplateDTOList> CitTemplateDTOList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"CitTemplateDTOList Count:{CitTemplateDTOList.Count}";
            return status;
        }
    }

    public class CitTemplateDTOList
    {
        public int VersionCode { get; set; }
        public string VersionName { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public string Notes { get; set; }
        public bool IsObsolete { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}