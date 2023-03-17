using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class StateDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<StateDTOList> StateDTOList { get; set; }

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
            status += $"StateDTO List Count:{this.StateDTOList.Count}";
            return status;
        }
    }

    public class StateDTOList
    {
        public string StateId { get; set; }
        public string State { get; set; }
        public int StateCode { get; set; }
        public string IsDeleted { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}