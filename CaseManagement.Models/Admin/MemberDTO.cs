using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class MemberDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<MemberDTOList> MemberDTOList { get; set; }

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
            status += $"MemberDTOList Count:{this.MemberDTOList.Count}";
            return status;
        }
    }

    public class MemberDTOList
    {
        public int MemberCode { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string Category { get; set; }
        public string IsLawyer { get; set; }
        public string IsTMCMember { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string IsDeleted { get; set; }
        public string IsConsentRequired { get; set; }
        public int MemberDataAccessCode { get; set; }
        public int DataAccessRuleCode { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}