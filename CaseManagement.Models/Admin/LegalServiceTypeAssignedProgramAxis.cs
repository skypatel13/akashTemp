using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceTypeAssignedProgramAxis
    {
        public int LegalServiceTypeMapCode { get; set; }
        public string LegalServiceTypeId { get; set; }
        public int ProgramAxisCode { get; set; }
        public string ProgramAxis { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
