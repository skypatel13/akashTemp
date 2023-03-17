using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Reports
{
    public class AlertDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<AlertDTOList> AlertDTOList { get; set; }
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
            status += $"AlertDTOList Count:{AlertDTOList.Count}";
            return status;
        }
    }
    public class AlertDTOList
    {
        public int RulesId { get; set; }
        public string NotificationTitle { get; set; }
        public int MessageId { get; set; }
        public string AlertMessage { get; set; }
        public DateTime? ReadOn { get; set; }
        public DateTime? ArchivedOn { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
