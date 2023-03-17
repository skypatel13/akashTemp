using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class LawyerDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public LawyerDTODetail LawyerDTODetail { get; set; }

        public override string ToString()
        {
            if (DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"LawyerDTODetail :{this.LawyerDTODetail}";
            return status;
        }
    }

    public class LawyerDTODetail
    {
        public int SurvivorLawyerCode { get; set; }
        public int SurvivorCode { get; set; }
        public int MemberLawyerTypeCode { get; set; }
        public int MemberCode { get; set; }
        public string MemberName { get; set; }
        public int LawyerTypeCode { get; set; }
        public string LawyerType { get; set; }
        public int SourceDestinationCode { get; set; }
        public string SourceDestination { get; set; }
        public string LeadingFor { get; set; }
        public bool IsLeadingValue { get; set; }
        public string IsLeadingText { get; set; }
        public DateTime? LeadingFrom { get; set; }
        public DateTime? LeadingTo { get; set; }
        public string Notes { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public DateTime? CreatedOn { get; set; }
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