using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class MemberSurvivorDTOAddDB
    {
        public int MemberDataAccessCode { get; set; }
        public int DataAccessRuleCode { get; set; }
        public string SurvivorData { get; set; }
        public string OrganizationData { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}