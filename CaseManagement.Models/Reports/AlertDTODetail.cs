using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Reports
{
    public class AlertDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public AlertDTODetail AlertDTODetail { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!this.DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"AlertDTODetail :{this.AlertDTODetail}";
            return status;
        }
    }

    public class AlertDTODetail
    {
        public int MessageId { get; set; }
        public string NotificationTitle { get; set; }
        public string AlertMessage { get; set; }
        public string UserId { get; set; }
        public DateTime? ReadOn { get; set; }
        public DateTime? ArchivedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}