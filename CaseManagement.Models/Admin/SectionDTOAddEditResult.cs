using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class SectionDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SectionDTODetail SectionDTODetail { get; set; }

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
            status += $" SectionDTODetail:{this.SectionDTODetail}";
            return status;
        }
    }
}