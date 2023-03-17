using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Reports
{
    public class MonthlyReportDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public ScheduleMemberDTO ScheduleMemberDTO { get; set; }
        public List<ScheduleVcPcDTODetail> ScheduleVcPcDTODetail { get; set; }
        public List<ScheduleTafteeshDTODetail> ScheduleTafteeshDTODetail { get; set; }
        public ScheduleVCDTOSummary ScheduleVCDTOSummary { get; set; }
        public List<ScheduleVcResultWiseDTO> ScheduleVcResultWiseDTO { get; set; }
        public List<ScheduleEngagementSurvivorList> ScheduleEngagementSurvivorList { get; set; }
        public List<ScheduleSurvivorMeetingDTO> ScheduleSurvivorMeetingDTO { get; set; }
        public List<ScheduleEngagementSurvivorList> ScheduleEngagementStackHolderList { get; set; }
        public List<ScheduleStackHolderMeetingDTO> ScheduleStackHolderMeetingDTO { get; set; }
        public List<ScheduleInvetigationTypeDTO> ScheduleInvetigationTypeDTO { get; set; }
        public List<ScheduleInvetigationAgencyTransferDTO> ScheduleInvetigationAgencyTransferDTO { get; set; }

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
            status += $"ScheduleMemberDTO :{ScheduleMemberDTO}";
            return status;
        }
    }

    public class ScheduleMemberDTO
    {
        public int ScheduleCode { get; set; }
        public int ScheduleMemberCode { get; set; }
        public string Duration { get; set; }
        public int MemberCode { get; set; }
        public string MemberName { get; set; }
        public string UserName { get; set; }
        public string Organization { get; set; }
        public int TotalSurvivor { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ScheduleTafteeshDTODetail
    {
        public int ScheduleMemberCode { get; set; }
        public int ScheduleTafteeshCode { get; set; }
        public int TafteeshStatusLogCode { get; set; }
        public string TafteeshStatusLog { get; set; }
        public int Total { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ScheduleVCDTOSummary
    {
        public int ScheduleMemberCode { get; set; }
        public int VCOverAll { get; set; }
        public int VCThisMonth { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ScheduleVcPcDTODetail
    {
        public int ScheduleSurvivorCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string PC_SA_Count { get; set; }
        public string PC_DA_Count { get; set; }
        public string VC_Count { get; set; }
        public string Rehabilitation_Count { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ScheduleVcResultWiseDTO
    {
        public string VCResult { get; set; }
        public string IsCurrent { get; set; }
        public int Total { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ScheduleEngagementSurvivorList
    {
        public int ScheduleEngagementCode { get; set; }
        public int ScheduleMemberCode { get; set; }
        public int SurvivorCode { get; set; }
        public string RelatedTo { get; set; }
        public string MeetingLocation { get; set; }
        public string MeetingMode { get; set; }
        public string Status { get; set; }
        public DateTime PlanToCloseOn { get; set; }
        public DateTime ClosedOn { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class ScheduleSurvivorMeetingDTO
    {
        public int ScheduleEngagementCode { get; set; }
        public int ScheduleMemberCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public DateTime LastMeetingOn { get; set; }
        public int DaysSinceLastMeeting { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class ScheduleStackHolderMeetingDTO
    {
        public int ScheduleEngagementCode { get; set; }
        public int ScheduleMemberCode { get; set; }
        public string StackHolderName { get; set; }
        public DateTime LastMeetingOn { get; set; }
        public int DaysSinceLastMeeting { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class ScheduleInvetigationTypeDTO
    {
        public string InvestingAgencyType { get; set; }
        public int Total { get; set; }
    }
    public class ScheduleInvetigationAgencyTransferDTO
    {
        public string SurvivorName { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}