using CaseManagement.Models.Common;
namespace CaseManagement.Models.Admin
{
    public class LegalServiceTypeDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public LegalServiceTypeDTODetail LegalServiceTypeDTODetail { get; set; }

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
            status += $" LegalServiceTypeDTODetail:{this.LegalServiceTypeDTODetail}";
            return status;
        }
    }
}
