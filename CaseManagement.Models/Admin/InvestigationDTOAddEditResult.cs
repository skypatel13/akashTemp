using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class InvestigationDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public InvestigationDTODetail InvestigationDTODetail { get; set; }

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
            status += $"InvestigationDTODetail :{this.InvestigationDTODetail}";
            return status;
        }
    }
}