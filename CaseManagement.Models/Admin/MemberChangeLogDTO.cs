using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class MemberChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<MemberChangeLogDTOList> MemberChangeLogDTOList { get; set; }
        public List<MemberRoleChangeLogDTOList> MemberRoleChangeLogDTOList { get; set; }
        public List<MemberLawyerTypeChangeLogDTOList> MemberLawyerTypeChangeLogDTOList { get; set; }

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
            status += $"MemberChangeLogDTOList Count:{this.MemberChangeLogDTOList.Count}";
            status += $"MemberRoleChangeLogDTOList Count:{this.MemberRoleChangeLogDTOList.Count}";
            if (this.MemberLawyerTypeChangeLogDTOList!=null)
            status += $"MemberLawyerTypeChangeLogDTOList Count:{this.MemberLawyerTypeChangeLogDTOList.Count}";
            return status;
        }
    }

    public class MemberChangeLogDTOList
    {
        public int MemberCode { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string Category { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string IsTMCMember { get; set; }
        public string IsLawyer { get; set; }
        public string UserID { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class MemberRoleChangeLogDTOList
    {
        public int MemberCode { get; set; }
        public string UserID { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class MemberLawyerTypeChangeLogDTOList
    {
        public int MemberLawyerTypeCode { get; set; }
        public int MemberCode { get; set; }
        public int LawyerTypeCode { get; set; }
        public string LawyerType { get; set; }
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