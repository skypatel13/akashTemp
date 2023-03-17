using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class OrganizationDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<OrganizationDTOList> OrganizationDTOList { get; set; }

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
            status += $"OrganizationDTO List Count:{this.OrganizationDTOList.Count}";
            return status;
        }
    }

    public class OrganizationDTOList
    {
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string District { get; set; }
        public int DistrictCode { get; set; }
        public int StateCode { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public string IsDeleted { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}