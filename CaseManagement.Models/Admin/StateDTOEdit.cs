using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class StateDTOEdit
    {
        public int StateCode { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}