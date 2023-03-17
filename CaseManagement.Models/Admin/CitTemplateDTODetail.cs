using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class CitDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public CitTemplateDTODetail CitTemplateDTODetail { get; set; }

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
            status += $"CitTemplateDTODetail :{CitTemplateDTODetail}";
            return status;
        }
    }

    public class CitTemplateDTODetail
    {
        public int VersionCode { get; set; }
        public string VersionName { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public string IsObsolete { get; set; }
        public DateTime? ObsoleteOn { get; set; }
        public string ObsoleteBy { get; set; }
        public string ObsoleteByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}