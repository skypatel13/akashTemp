using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class InvestigationChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<InvestigationChangeLogDTOList> InvestigationChangeLogDTOList { get; set; }
        public List<InvestigationAgencyChangeLogDTOList> InvestigationAgencyChangeLogDTOList { get; set; }
        public List<InvestigationStatusChangeLogDTOList> InvestigationStatusChangeLogDTOList { get; set; }

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
            status += $"InvestigationChangeLogDTOList :{InvestigationChangeLogDTOList.Count}";
            status += $"InvestigationAgencyChangeLogDTOList :{InvestigationAgencyChangeLogDTOList.Count}";
            status += $"InvestigationStatusChangeLogDTOList :{InvestigationStatusChangeLogDTOList.Count}";
            return status;
        }
    }

    public class InvestigationChangeLogDTOList
    {
        public int InvestigationCode { get; set; }
        public int FIRCode { get; set; }
        public string FIRNumber { get; set; }
        public string SourceDestination { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public string IsAccepted { get; set; }
        public string AcceptanceReason { get; set; }
        public int SurvivorCode { get; set; }
        public string IsDeleted { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class InvestigationAgencyChangeLogDTOList
    {
        public int InvestigationAgencyLogCode { get; set; }
        public int FIRCode { get; set; }
        public string FIRNumber { get; set; }
        public string SourceDestination { get; set; }
        public int SurvivorCode { get; set; }
        public int InvestigationCode { get; set; }
        public int InvestingAgencyCode { get; set; }
        public string InvestingAgency { get; set; }
        public int InvestingAgencyTypeCode { get; set; }
        public string InvestingAgencyType { get; set; }
        public string InvestigatingOfficer { get; set; }
        public int OfficerRankCode { get; set; }
        public string OfficerRank { get; set; }
        public int ReasonCode { get; set; }
        public string Reason { get; set; }
        public DateTime? ChangeDate { get; set; }
        public int ChangeTypeCode { get; set; }
        public string ChangeType { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class InvestigationStatusChangeLogDTOList
    {
        public int InvestigationStatusLogCode { get; set; }
        public int FIRCode { get; set; }
        public string FIRNumber { get; set; }
        public string SourceDestination { get; set; }
        public int SurvivorCode { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public int ResultCode { get; set; }
        public string Result { get; set; }
        public DateTime? ResultDate { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}