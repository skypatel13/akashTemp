using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class TraffickerDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public TraffickerDTODetail TraffickerDTODetail { get; set; }

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
            status += $"TraffickerDTODetail :{this.TraffickerDTODetail}";
            return status;
        }
    }

    public class TraffickerDTODetail
    {
        public int TraffickerCode { get; set; }
        public string TraffickerId { get; set; }
        public string TraffickerName { get; set; }
        public int GenderCode { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string Alias { get; set; }
        public string IdentificationMark { get; set; }
        public string Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public string Notes { get; set; }
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