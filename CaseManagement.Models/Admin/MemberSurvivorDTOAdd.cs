using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class MemberSurvivorDTOAdd
    {
        public int MemberDataAccessCode { get; set; }
        public int DataAccessRuleCode { get; set; }
        public List<MemberSurvivorMappingOrganizationDTOList> memberSurvivorMappingOrganizationDTOList { get; set; }
        public List<MemberSurvivorMappingDTOList> MemberSurvivorMappingDTOList { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class MemberSurvivorMappingOrganizationDTOList
    {
        public int OrganizationId { get; set; }
    }
}