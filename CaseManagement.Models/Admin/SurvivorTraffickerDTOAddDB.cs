using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorTraffickerDTOAddDB
    {
        public int SurvivorCode { get; set; }
        public string DataXML { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}