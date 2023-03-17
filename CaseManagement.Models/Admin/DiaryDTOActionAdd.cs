using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class DiaryDTOActionAdd
    {
        public int DailyDiaryId { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}