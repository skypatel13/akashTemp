using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class MemberLawyerTypeAssignedDTOList
    {
        public int MemberCode { get; set; }
        public int LawyerTypeCode { get; set; }
        public string LawyerType { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}