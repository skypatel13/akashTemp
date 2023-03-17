using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class TraffickerChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<TraffickerChangeLogDTOList> TraffickerChangeLogDTOList { get; set; }
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
            status += $"TraffickerChangeLogDTOList Count:{this.TraffickerChangeLogDTOList.Count}";
            return status;
        }
    }
    public class TraffickerChangeLogDTOList
    {
        public int TraffickerCode { get; set; }
        public string TraffickerId { get; set; }
        public string TraffickerName { get; set; }
        public int GenderCode { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Alias { get; set; }
        public string IdentificationMark { get; set; }
        public string Notes { get; set; }
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
