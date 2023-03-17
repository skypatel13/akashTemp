using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class TraffickerDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<TraffickerDTOList> TraffickerDTOList { get; set; }
        public List<TraffickerStatusLog> TraffickerStatusLogs { get; set; }

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
            status += $"TraffickerDTOList Count:{this.TraffickerDTOList.Count}";
            status += $"Trafficker Status Log Count:{this.TraffickerStatusLogs.Count}";
            return status;
        }
    }

    public class TraffickerDTOList
    {
        public int TraffickerCode { get; set; }
        public string TraffickerId { get; set; }
        public string TraffickerName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Alias { get; set; }
        public string IdentificationMark { get; set; }
        public string Status { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class TraffickerStatusLog
    {
        public int TraffickerStatusLogCode { get; set; }
        public int TraffickerCode { get; set; }
        public string TraffickerName { get; set; }
        public string Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}