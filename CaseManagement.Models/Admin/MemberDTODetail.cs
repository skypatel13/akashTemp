using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class MemberDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public MemberDTODetail MemberDTODetail { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"MemberDTODetail :{this.MemberDTODetail},MemberRoleAssignedDTOList Count:{this.MemberDTODetail.MemberRoleAssignedDTOList},MemberLawyerTypeAssignedDTOList Count:{(this.MemberDTODetail.MemberLawyerTypeAssignedDTOList != null ? this.MemberDTODetail.MemberLawyerTypeAssignedDTOList.Count : 0)}";
            return status;
        }
    }

    public class MemberDTODetail
    {
        public int MemberCode { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string Category { get; set; }
        public string TMCMemberText { get; set; }
        public bool TMCMemberValue { get; set; }
        public string LawyerText { get; set; }
        public bool LawyerValue { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string UserID { get; set; }
        public bool IsConsentRequiredValue { get; set; }
        public string IsConsentRequiredText { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public List<MemberLawyerTypeAssignedDTOList> MemberLawyerTypeAssignedDTOList { get; set; }
        public List<MemberRoleAssignedDTOList> MemberRoleAssignedDTOList { get; set; }
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