using CaseManagement.Models.Common;

namespace CaseManagement.Models.Admin
{
    public class MemberCredentialDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public MemberCredentialDTODetail MemberCredentialDTODetail { get; set; }

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
            status += $"MemberCredentialDTODetail Count:{MemberCredentialDTODetail}";
            return status;
        }
    }

    public class MemberCredentialDTODetail
    {
        public int MemberCode { get; set; }
        public string MemberName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}