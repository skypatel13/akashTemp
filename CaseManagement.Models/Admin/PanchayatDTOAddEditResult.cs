using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class PanchayatDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public PanchayatDTODetail PanchayatDTODetail { get; set; }
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
            return status += $"PanchayatDTODetail :{this.PanchayatDTODetail}";
        }
    }
}
