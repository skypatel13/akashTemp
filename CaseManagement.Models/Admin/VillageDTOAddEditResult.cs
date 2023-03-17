using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class VillageDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public VillageDTODetail VillageDTODetail { get; set; }
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
            return status += $"VillageDTODetail :{this.VillageDTODetail}";

        }
    }
}
