using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class MemberRoleDTOList
    {
        public string RoleId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}