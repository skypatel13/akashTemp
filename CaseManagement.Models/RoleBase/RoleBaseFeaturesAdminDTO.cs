using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.RoleBase
{
    public class RoleBaseFeaturesAdminDTO
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public RoleBaseDTOHeader RoleBaseDTOHeader { get; set; }
        public List<RoleBaseFeatureAdminDTO> roleBaseFeatureAdminDTO { get; set; }
        public List<RoleBaseActionAdminDTO> roleBaseActionAdminDTO { get; set; }
        public List<RoleBaseFeatureActionFMap> roleBaseFeatureActionFMap { get; set; }
        public List<RoleBaseFeatureActionFAMap> roleBaseFeatureActionFAMap { get; set; }
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
            status += $"RoleBaseDTOHeader :{this.RoleBaseDTOHeader}," +
                      $"RoleBaseFeatureAdminDTO Count:{(this.roleBaseFeatureAdminDTO != null ? this.roleBaseFeatureAdminDTO.Count : 0)}," +
                      $"RoleBaseActionAdminDTO Count:{(this.roleBaseActionAdminDTO != null ? this.roleBaseActionAdminDTO.Count : 0)}," +
                      $"RoleBaseFeatureActionFMap Count:{(this.roleBaseFeatureActionFMap != null ? this.roleBaseFeatureActionFMap.Count : 0)}" +
                      $"RoleBaseFeatureActionFAMap Count:{(this.roleBaseFeatureActionFAMap != null ? this.roleBaseFeatureActionFAMap.Count : 0)}";
            return status;
        }
    }
    public class RoleBaseDTOHeader
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class RoleBaseFeatureAdminDTO
    {
        public int FeaturesCode { get; set; }
        public string Name { get; set; }
        public int FeatureNo { get; set; }
        public int FeaturesTypeCode { get; set; }
        public string FeatureType { get; set; }
        public Boolean IsGranted { get; set; }
    }
    public class RoleBaseActionAdminDTO
    {
        public int FeatureNo { get; set; }
        public int FeaturesActionCode { get; set; }
        public string Name { get; set; }
        public int RoleFeaturesCode { get; set; }
        public Boolean IsGranted { get; set; }
    }
    public class RoleBaseFeatureActionFMap
    {
        public int FeaturesActionFMapCode { get; set; }
        public int SourceFeaturesActionCode { get; set; }
        public int DestinationFeatureNo { get; set; }
    }
    public class RoleBaseFeatureActionFAMap
    {
        public int FeaturesActionFAMapCode { get; set; }
        public int SourceFeaturesActionCode { get; set; }
        public int DestinationFeaturesActionCode { get; set; }
    }
}
