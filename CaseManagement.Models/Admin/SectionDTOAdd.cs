using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SectionDTOAdd
    {
        public string Section { get; set; }
        public string Title { get; set; }
        public int ActCode { get; set; }
        public string Notes { get; set; }
        public bool IsForMinor { get; set; }
        public string RefURL { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}