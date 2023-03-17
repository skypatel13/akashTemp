using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class AlertRuleDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<AlertRuleDTO> alertRules { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Alert Rules List Count:{this.alertRules.Count}";
            return status;
        }
    }
    public class AlertRuleDTO
    {
        public int RulesId { get; set; }
        public string Reason { get; set; }
        public string ReferenceSP { get; set; }
        public int NotificationScopeCode { get; set; }
        public string NotificationScope { get; set; }
        public string NotificationTitle { get; set; }
        public string AlertMessage { get; set; }
        public int SeqNo { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
