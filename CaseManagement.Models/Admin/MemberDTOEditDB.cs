using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class MemberDTOEditDB
    {
        public int MemberCode { get; set; }
        public string MemberName { get; set; }
        public string Category { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int OrganizationId { get; set; }
        public bool IsTMCMember { get; set; }
        public bool IsLawyer { get; set; }
        public string UserRole { get; set; } // Member Have Multiple Role, This Field containt XML Data 
        public string LawyerType { get; set; } // Member Have Multiple Lawyer Type, This Field containt XML Data 
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}