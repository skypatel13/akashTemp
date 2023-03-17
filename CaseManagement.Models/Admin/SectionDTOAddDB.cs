using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SectionDTOAddDB
    {
        public string Section { get; set; }
        public string Title { get; set; }
        public int ActCode { get; set; }
        public string Notes { get; set; }
        public bool IsForMinor { get; set; }
        public string RefURL { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}