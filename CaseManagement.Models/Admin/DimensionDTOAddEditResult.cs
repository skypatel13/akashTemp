using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class DimensionDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public DimensionDTODetail DimensionDTODetail { get; set; }

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
            status += $"DimensionDTODetail :{this.DimensionDTODetail}";
            return status;
        }
    }
}