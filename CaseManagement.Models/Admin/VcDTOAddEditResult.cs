using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class VcDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public VcDTODetail VcDTODetail { get; set; }

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
            status += $"VcDTODetail :{ this.VcDTODetail}";
            return status;
        }
    }
}