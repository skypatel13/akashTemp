using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class RescueDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public RescueDTODetail RescueDTODetail { get; set; }

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
            status += $" RescueDTODetail:{this.RescueDTODetail}";
            return status;
        }
    }
}