using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class FirDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public FirDTODetail FirDTODetail { get; set; }

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
            status += $"FirDTODetail :{this.FirDTODetail}";
            return status;
        }
    }
}