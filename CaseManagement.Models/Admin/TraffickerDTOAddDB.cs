using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class TraffickerDTOAddDB
    {
        public string TraffickerName { get; set; }
        public int GenderCode { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string Alias { get; set; }
        public string IdentificationMark { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}