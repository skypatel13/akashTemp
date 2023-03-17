using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class InvestigationDTOEditDB
    {
        public int InvestigationCode { get; set; }
        public int FIRCode { get; set; }
        public int StatusCode { get; set; }
        public int ResultCode { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}