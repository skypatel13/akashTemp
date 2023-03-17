using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class StateDTOEditDB
    {
        public int StateCode { get; set; }
        public string State { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}