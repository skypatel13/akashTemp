using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DiaryDTODetailResponse
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
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"DiaryDTODetail :{DiaryDTODetail}";
            return status;
        }
    }
    public class DiaryDTODetail
    {
        public int DailyDiaryId { get; set; }
        public string Details { get; set; }
        public int ModuleCode { get; set; }
        public string Module { get; set; }
        public int RemindBeforeDays { get; set; }
        public int RelatedToCode { get; set; }
        public string RelatedTo { get; set; }
        public List<DiarySurvivorDTOList> DiarySurvivorDTOList { get; set; }
        public List<DiaryStakeholdersDTOList> DiaryStakeholdersDTOList { get; set; }
        public int MeetingModeCode { get; set; }
        public string MeetingMode { get; set; }
        public int MeetingLocationCode { get; set; }
        public string MeetingLocation { get; set; }
        public int DailyDiaryTypeCode { get; set; }
        public string DailyDiaryType { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
        public DateTime PlanToCloseOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}