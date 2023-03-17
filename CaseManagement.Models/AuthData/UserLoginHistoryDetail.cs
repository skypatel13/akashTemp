using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.AuthData
{
    public class UserLoginHistoryDetail
    {
        public Guid LoginHistoryId { get; set; }
        public string Uname { get; set; }
        public DateTime LoginOn { get; set; }
        public string UserAgent { get; set; }
        public string IPAddress { get; set; }
        public bool IsConsentRequired { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
