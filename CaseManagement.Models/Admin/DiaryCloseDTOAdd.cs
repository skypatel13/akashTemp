using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class DiaryCloseDTOAdd
    {
        public int DailyDiaryId { get; set; }
        public DateTime ClosedOn { get; set; }
        public int StatusCode { get; set; }
        public string Result { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}