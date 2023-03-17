using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class SurvivorGrantDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorGrantDTODetail SurvivorGrantDTODetail { get; set; }

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
            status += $" Survivor Grant Detail:{this.SurvivorGrantDTODetail}";
            return status;
        }
    }
}
