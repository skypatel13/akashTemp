using Newtonsoft.Json;

namespace CaseManagement.Models.Common
{
    public class DataUpdateResponseDTO
    {
        public bool Status { get; set; }
        public string Description { get; set; }
        public int RecordCount { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}