using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class BlockDTOAdd
    {
        public string Block { get; set; }
        public int BlockMunicipalityCode { get; set; }
        public int DistrictCode { get; set; }
        public int StateCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}