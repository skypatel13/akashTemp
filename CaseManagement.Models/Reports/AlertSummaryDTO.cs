using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Reports
{
    public class AlertSummaryDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<AlertSummaryDTOList> AlertSummaryDTOList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"AlertSummaryDTOList Count:{AlertSummaryDTOList.Count}";
            return status;
        }
    }

    public class AlertSummaryDTOList
    {
        public int RulesId { get; set; }
        public string NotificationTitle { get; set; }
        public int Total { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}