using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DiaryDTOEdit
    {
        public int DailyDiaryId { get; set; }
        public string Details { get; set; }
        public DateTime PlanToCloseOn { get; set; }
        public int ModuleCode { get; set; }
        public int RelatedToCode { get; set; }
        public List<DiarySurvivorMappingDTOAdd> DiarySurvivorMappingDTOAdd { get; set; }
        public List<DiaryStackeHoldeMappingDTOAdd> DiaryStackeHoldeMappingDTOAdd { get; set; }
        public int RemindBeforeDays { get; set; }
        public int? MeetingModeCode { get; set; }
        public int? MeetingLocationCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}