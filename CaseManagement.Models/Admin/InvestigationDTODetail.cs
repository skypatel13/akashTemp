using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class InvestigationDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public InvestigationDTODetail InvestigationDTODetail { get; set; }

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
            status += $"InvestigationDTODetail :{InvestigationDTODetail}";
            return status;
        }
    }

    public class InvestigationDTODetail
    {
        public int InvestigationCode { get; set; }
        public DateTime? AcceptanceDate { get; set; }
        public string IsAccepted { get; set; }
        public string AcceptanceReason { get; set; }
        public int InvestingAgencyCode { get; set; }
        public string InvestingAgency { get; set; }
        public int InvestingAgencyTypeCode { get; set; }
        public string InvestingAgencyType { get; set; }
        public string InvestigatingOfficer { get; set; }
        public int OfficerRankCode { get; set; }
        public string OfficerRank { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public int ResultCode { get; set; }
        public string Result { get; set; }
        public string Notes { get; set; }
        public int FIRCode { get; set; }
        public string SourceDestination { get; set; }
        public string PoliceStationName { get; set; }
        public string FIRNumber { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
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