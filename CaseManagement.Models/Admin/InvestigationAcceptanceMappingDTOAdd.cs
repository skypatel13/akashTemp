using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class InvestigationAcceptanceMappingDTOAdd
    {
        public int AcceptanceReasonCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}