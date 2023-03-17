using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class VillageDTOEditDB
    {
        public int VillageCode { get; set; }
        public string Village { get; set; }
        public int BlockCode { get; set; }
        public int DistrictCode { get; set; }
        public int StateCode { get; set; }
        public bool IsWard { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
