using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class DiaryDTOStatusUpdate
    {
        public int DailyDiaryId { get; set; }
        public int StatusCode { get; set; }
        public string Result { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}