using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class ShelterHomeDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public ShelterHomeDTODetail ShelterHomeDTODetail { get; set; }

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
            status += $"ShelterHomeDTODetail :{this.ShelterHomeDTODetail}";
            return status;
        }
    }
}