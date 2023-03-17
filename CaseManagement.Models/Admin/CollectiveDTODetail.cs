using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class CollectiveDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public CollectiveDTODetail CollectiveDTODetail { get; set; }

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
            status += $"CollectiveDTO Detail:{this.CollectiveDTODetail}";
            return status;
        }
    }

    public class CollectiveDTODetail
    {
        public int CollectiveCode { get; set; }
        public string CollectiveName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}