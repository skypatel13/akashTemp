using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.AuthData
{
    /// <summary>
    /// Model to store and share token details with token string, expiration and role of a user
    /// </summary>
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Role { get; set; }
        public string LoginHistoryId { get; set; }
        public DateTime LoginOn { get; set; }
        public bool IsConsentRequired { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}