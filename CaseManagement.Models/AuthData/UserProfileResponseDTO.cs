using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.AuthData
{
    public class UserProfileResponseDTO
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public UserProfileDetail UserProfileDetail { get; set; }
        public List<UserProfileRoles> UserProfileRoles { get; set; }
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
            status += $"User Profile Detail Count:{this.UserProfileDetail};";
            status += $"User Profile Roles Count:{this.UserProfileRoles.Count};";
            return status;
        }
    }
    public class UserProfileDetail
    {
        public string MemberName { get; set; }
        public string Designation { get; set; }
        public string IsTMCMember { get; set; }
        public string IsLawyer { get; set; }
        public string Organization { get; set; }
        public string IsConsentRequired { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class UserProfileRoles
    {
        public int MemberCode { get; set; }
        public string UserID { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
