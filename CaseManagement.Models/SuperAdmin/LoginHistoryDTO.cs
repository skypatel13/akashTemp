using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.SuperAdmin
{
    public class LoginHistoryDTO
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LoginHistoryLog> LoginHistoryLog { get; set; }
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
            status += $"Login History Log Count:{this.LoginHistoryLog.Count};";
            return status;
        }
    }
    public class LoginHistoryLog
    {
        public Guid LoginHistoryId { get; set; }
        public string UserName { get; set; }
        public string MemberName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string IPAddress { get; set; }
        public DateTime? LoginOn { get; set; }
        public DateTime? LogOutOn { get; set; }
        public string IsRefreshed { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
