using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class MemberLawyerTypeDTOList
    {
        public int LawyerTypeCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}