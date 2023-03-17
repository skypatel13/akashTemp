using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceProviderDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public LegalServiceProviderDTODetail LegalServiceProviderDTODetail { get; set; }

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
            status += $" LegalServiceProviderDTODetail:{this.LegalServiceProviderDTODetail}";
            return status;
        }
    }
}