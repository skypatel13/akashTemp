using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class MemberDTOEdit
    {
        public int MemberCode { get; set; }
        public string MemberName { get; set; }
        public string Category { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int OrganizationId { get; set; }
        public bool IsTMCMember { get; set; }
        public bool IsLawyer { get; set; }
        public List<MemberRoleDTOList> MemberRoleLists { get; set; }
        public List<MemberLawyerTypeDTOList> MemberLawyerTypeDTOLists { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}