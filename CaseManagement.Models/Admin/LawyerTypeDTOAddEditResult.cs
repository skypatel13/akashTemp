using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class LawyerTypeDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public LawyerTypeDTODetail LawyerTypeDTODetail { get; set; }

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
            status += $" LawyerTypeDTODetail:{this.LawyerTypeDTODetail}";
            return status;
        }
    }
}