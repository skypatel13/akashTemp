using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class CollectiveDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<CollectiveDTOList> CollectiveDTOList { get; set; }

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
            status += $"CollectiveDTO List:{this.CollectiveDTOList.Count}";
            return status;
        }
    }

    public class CollectiveDTOList
    {
        public int CollectiveCode { get; set; }
        public string CollectiveName { get; set; }
        public string OrganizationId { get; set; }
        public string Organization { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}