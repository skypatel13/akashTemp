using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class DiaryStackeHoldeMappingDTOAdd
    {
        public int StakeholderTypeCode { get; set; }
        public string StakeholderName { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}