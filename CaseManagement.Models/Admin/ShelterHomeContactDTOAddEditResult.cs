using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class ShelterHomeContactDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public ShelterHomeContactDTODetail ShelterHomeContactDTODetail { get; set; }

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
            status += $"ShelterHomeContactDTODetail :{this.ShelterHomeContactDTODetail}";
            return status;
        }
    }
}