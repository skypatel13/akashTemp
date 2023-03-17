using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class DiaryDTOActionAddDB
    {
        public int DailyDiaryId { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}