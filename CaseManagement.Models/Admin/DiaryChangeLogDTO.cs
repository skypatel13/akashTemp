using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DiaryChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DiaryChangeLogDTOList> DiaryChangeLogDTOList { get; set; }
        public List<DiarySurvivorChangeLogDTOList> DiarySurvivorChangeLogDTOList { get; set; }
        public List<DiaryStackeHoldeChangeLogDTOList> DiaryStackeHoldeChangeLogDTOList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!this.DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"DiaryChangeLogDTOList Count:{this.DiaryChangeLogDTOList.Count}";
            status += $"DiarySurvivorChangeLogDTOList Count:{this.DiarySurvivorChangeLogDTOList?.Count}";
            status += $"DiaryStackeHoldeChangeLogDTOList Count:{this.DiaryStackeHoldeChangeLogDTOList?.Count}";
            return status;
        }
    }

    public class DiaryChangeLogDTOList
    {
        public int DailyDiaryId { get; set; }
        public string Details { get; set; }
        public int ModuleCode { get; set; }
        public string Module { get; set; }
        public int RemindBeforeDays { get; set; }
        public int RelatedToCode { get; set; }
        public string RelatedTo { get; set; }
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
        public int MemberCode { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class DiarySurvivorChangeLogDTOList
    {
        public int DailyDiarySurvivorsId { get; set; }
        public int DailyDiaryId { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class DiaryStackeHoldeChangeLogDTOList
    {
        public int DailyDiaryStakeholdersId { get; set; }
        public int DailyDiaryId { get; set; }
        public int StakeholderTypeCode { get; set; }
        public string StakeholderType { get; set; }
        public string StakeholderName { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}