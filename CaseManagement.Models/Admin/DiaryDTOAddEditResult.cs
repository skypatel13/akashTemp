using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class DiaryDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public DiaryDTODetail DiaryDTODetail { get; set; }

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
            return status += $"DailyDiaryDTODetail :{this.DiaryDTODetail}";
        }
    }
}