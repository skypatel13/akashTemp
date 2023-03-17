using Newtonsoft.Json;

namespace CaseManagement.Models.Reports
{
    public class EmailUpdateResponseDTO
    {
        public int EmailCode { get; set; }
        public bool IsSent { get; set; }
        public string ExceptionDetails { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}