using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class TraffickerStatusResponse
    {
        public DataUpdateResponseDTO dataUpdateResponse { get; set; }
        public TraffickerDTODetail traffickerDTODetail { get; set; }
        public override string ToString()
        {
            if (this.dataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = dataUpdateResponse.ToString();
            if (!dataUpdateResponse.Status)
            {
                return status;
            }
            status += $"Trafficker Detail :{this.traffickerDTODetail};";
            return status;
        }
    }
    public class TraffickerStatusDTOAddDB
    {
        public int TraffickerCode { get; set; }
        public int StatusCode { get; set; }
        public DateTime? StatusDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
