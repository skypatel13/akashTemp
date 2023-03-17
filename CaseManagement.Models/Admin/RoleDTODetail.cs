using CaseManagement.Models.Common;
using System;

namespace CaseManagement.Models.Admin
{
    public class RoleDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public RoleDTODetail RoleDTODetail { get; set; }

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
            status += $"RoleDTODetail :{this.RoleDTODetail}";
            return status;
        }
    }
    public class RoleDTODetail
    {
        public string RoleId { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Role { get; set; }
        public string NormalizedName { get; set; }
        public string Purpose { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
    }
}