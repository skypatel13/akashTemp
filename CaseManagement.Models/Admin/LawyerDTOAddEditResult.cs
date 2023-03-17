using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class LawyerDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public LawyerDTODetail LawyerDTODetail { get; set; }

        public override string ToString()
        {
            if (DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $" LawyerDTODetail:{this.LawyerDTODetail}";
            return status;
        }
    }
}