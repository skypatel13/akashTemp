using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class StateDTOAdd
    {
        public string State { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}