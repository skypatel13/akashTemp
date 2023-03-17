using Newtonsoft.Json;
namespace CaseManagement.Models.Admin
{
    public class DistrictDTOAdd
    {
        public string District { get; set; }
        public string StateId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
     }
}
