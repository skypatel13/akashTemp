using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DiaryDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DiaryDTOList> DiaryDTOList { get; set; }
        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"DairyDTOList Count:{DiaryDTOList.Count}";
            return status;
        }
    }
    public class DiaryDTOList
    {
        public int DailyDiaryId { get; set; }
        public string Details { get; set; }
        public string Module { get; set; }
        public int RemindBeforeDays { get; set; }
        public string RelatedTo { get; set; }
        public string MeetingMode { get; set; }
        public int  MeetingLocationCode { get; set; }
        public string MeetingLocation { get; set; }
        public string DailyDiaryType { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string Result { get; set; }
        public DateTime PlanToCloseOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public int MemberCode { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}