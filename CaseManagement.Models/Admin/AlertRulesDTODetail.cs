using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class AlertRuleDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public AlertRulesDTODetail alertRulesDTODetail { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"Alert Rules Detail :{alertRulesDTODetail}";
            return status;
        }
    }
    public class AlertRulesDTODetail
    {
        public int RulesId { get; set; }
        public string Reason { get; set; }
        public string ReferenceSP { get; set; }
        public int NotificationScopeCode { get; set; }
        public string NotificationScope { get; set; }
        public string NotificationTitle { get; set; }
        public string AlertMessage { get; set; }
        public int SeqNo { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
