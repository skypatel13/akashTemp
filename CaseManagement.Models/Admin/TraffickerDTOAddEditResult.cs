using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace CaseManagement.Models.Admin
{
    public class TraffickerDTOAddEditResult
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
            status += $" TraffickerDTODetail:{this.TraffickerDTODetail}";
            return status;
        }
    }
}
