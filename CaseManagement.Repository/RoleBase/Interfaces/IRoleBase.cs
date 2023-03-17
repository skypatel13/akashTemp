using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Models.RoleBase;

namespace CaseManagement.Repository.RoleBase.Interfaces
{
    public interface IRoleBase
    {
        RoleBaseMenuDTO RoleBasedMenu_GetByUserName(string userName);
        RoleBaseFeaturesAdminDTO Features_GetByRole_Admin(string roleId, string userName);
        DataUpdateResponseDTO Features_Insert_ByRole_Admin(RoleBaseFeaturesDTOInsertDB roleBaseFeaturesDTOInsertDB);
    }
}
