using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class ActDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public ActDTODetail ActDTODetail { get; set; }

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
            status += $" ActDTODetail:{this.ActDTODetail}";
            return status;
        }
    }
}