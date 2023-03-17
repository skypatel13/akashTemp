using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class CollectiveChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<CollectiveChangeLogDTOList> CollectiveChangeLogDTOList { get; set; }

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
            status += $"CollectiveChangeLogDTO List:{this.CollectiveChangeLogDTOList.Count}";
            return status;
        }
    }

    public class CollectiveChangeLogDTOList
    {
        public int CollectiveCode { get; set; }
        public string CollectiveName { get; set; }
        public string OrganizationId { get; set; }
        public string Organization { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}