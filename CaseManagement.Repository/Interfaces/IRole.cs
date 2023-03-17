using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IRole
    {
        RoleDTOResponse List(string userName);

        DataUpdateResponseDTO Add(RoleDTOAddDB roleDTOAddDB);

        DataUpdateResponseDTO Edit(RoleDTOEditDB roleDTOEdit);

        DataUpdateResponseDTO Delete(string roleId, string deletedBy, string deletedByIpAddress);

        RoleDTOResponse DeletedList(string userName);

        RoleChangeLogDTOResponse ChangeLog_GetById(string roleId, string userName);

        RoleDTODetailResponse Detail(string roleId, string userName);
    }
}