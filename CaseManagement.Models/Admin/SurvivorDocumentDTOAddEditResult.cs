using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class SurvivorDocumentDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorDocumentDTODetail SurvivorDocumentDTODetail { get; set; }
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
            status += $"SurvivorDocumentDTODetail :{this.SurvivorDocumentDTODetail}";
            return status;
        }
    }
}
