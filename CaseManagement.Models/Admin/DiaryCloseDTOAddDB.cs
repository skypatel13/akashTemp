using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class DiaryCloseDTOAddDB
    {
        public int DailyDiaryId { get; set; }
        public DateTime ClosedOn { get; set; }
        public int StatusCode { get; set; }
        public string Result { get; set; }
        public string ClosedBy { get; set; }
        public string ClosedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}