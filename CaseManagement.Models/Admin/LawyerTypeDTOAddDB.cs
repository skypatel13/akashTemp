using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class LawyerTypeDTOAddDB
    {
        public string LawyerType { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}