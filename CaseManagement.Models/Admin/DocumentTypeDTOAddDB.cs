using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class DocumentTypeDTOAddDB
    {
        public string DocumentName { get; set; }
        public bool IsRequiredForSurvivor { get; set; }
        public bool IsSurvivorSpecific { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}