using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class DocumentTypeDTOEditDB
    {
        public int DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public bool IsRequiredForSurvivor { get; set; }
        public bool IsSurvivorSpecific { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}