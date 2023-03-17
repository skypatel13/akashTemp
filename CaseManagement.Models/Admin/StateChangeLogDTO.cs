using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class StateChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<StateChangeLogDTOList> StateChangeLogDTOList { get; set; }

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
            status += $"StateChangeLogDTO List:{this.StateChangeLogDTOList.Count}";
            return status;
        }
    }

    public class StateChangeLogDTOList
    {
        public string StateId { get; set; }
        public int StateCode { get; set; }
        public string State { get; set; }
        public string IsDeleted { get; set; }
        public string RecordMode { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}