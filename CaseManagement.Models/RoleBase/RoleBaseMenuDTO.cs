using CaseManagement.Models.Common;
using System.Collections.Generic;

namespace CaseManagement.Models.RoleBase
{
    public class RoleBaseMenuDTO
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<RoleBaseFeatureDTO> roleBaseFeatureDTO { get; set; }
        public List<RoleBaseActionDTO> roleBaseActionDTO { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!this.DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"RoleBaseFeatureDTO Count:{(this.roleBaseFeatureDTO != null ? this.roleBaseFeatureDTO.Count : 0)},RoleBaseActionDTO Count:{(this.roleBaseActionDTO != null ? this.roleBaseActionDTO.Count : 0)}";
            return status;
        }
    }
    public class RoleBaseFeatureDTO
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public int RoleFeaturesCode { get; set; }
        public int FeatureNo { get; set; }
        public string NavigationName { get; set; }
        public string NavigationLink { get; set; }
        public string DisplayTitle { get; set; }
    }
    public class RoleBaseActionDTO
    {
        public int RoleFeaturesCode { get; set; }
        public int RoleFeaturesActionCode { get; set; }
        public int FeatureNo { get; set; }
        public int ActionNo { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string DisplayTitle { get; set; }

    }
}
