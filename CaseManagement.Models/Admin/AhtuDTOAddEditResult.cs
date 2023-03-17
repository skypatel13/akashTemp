using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class AhtuDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public AhtuDTODetail AhtuDTODetail { get; set; }

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
            status += $"AhtuDTODetail :{this.AhtuDTODetail}";
            return status;
        }
    }
}