using CaseManagement.Models.Common;

namespace CaseManagement.Models.Reports
{
    public class AlertDTOAddEditResult
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
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"AlertDTODetail :{this.AlertDTODetail}";
            return status;
        }
    }
}