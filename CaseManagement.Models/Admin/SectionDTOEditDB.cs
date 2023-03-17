using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SectionDTOEditDB
    {
        public int ActSectionCode { get; set; }
        public string Section { get; set; }
        public string Title { get; set; }
        public int ActCode { get; set; }
        public string Notes { get; set; }
        public bool IsForMinor { get; set; }
        public string RefURL { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}