using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class VillageDTOAddDB
    {
        public string Village { get; set; }
        public int BlockCode { get; set; }
        public int DistrictCode { get; set; }
        public int StateCode { get; set; }
        public bool IsWard { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
