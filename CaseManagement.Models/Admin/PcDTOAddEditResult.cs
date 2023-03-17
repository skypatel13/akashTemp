using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class PcDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public PcDTODetail PcDTODetail { get; set; }

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
            status += $"PcDTODetail :{this.PcDTODetail}";
            return status;
        }
    }
}