using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class DiaryDTOEditDB
    {
        public int DailyDiaryId { get; set; }
        public string Details { get; set; }
        public DateTime PlanToCloseOn { get; set; }
        public int ModuleCode { get; set; }
        public int RelatedToCode { get; set; }
        public string SurvivorData { get; set; } //XML string
        public string StakeholderData { get; set; } //Comma separated string
        public int RemindBeforeDays { get; set; }
        public int? MeetingModeCode { get; set; }
        public int? MeetingLocationCode { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}