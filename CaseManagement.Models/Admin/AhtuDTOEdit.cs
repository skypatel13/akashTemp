using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class AhtuDTOEdit
    {
        public int AHTUCode { get; set; }
        public string AHTUName { get; set; }
        public int DistrictCode { get; set; }
        public int StateCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}