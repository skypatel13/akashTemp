using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class PartnerDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<PartnerDTOList> PartnerDTOList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"PartnerDTO List Count:{this.PartnerDTOList.Count}";
            return status;
        }
    }

    public class PartnerDTOList
    {
        public string PartnerId { get; set; }
        public int PartnerCode { get; set; }
        public string PartnerName { get; set; }
        public string Notes { get; set; }
        public string IsDeleted { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}