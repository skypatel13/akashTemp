using CaseManagement.Models.Common;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class MemberDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public MemberDTODetail MemberDTODetail { get; set; }
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
            status += $" MemberDTODetail:{this.MemberDTODetail}";
            return status;
        }
    }
}