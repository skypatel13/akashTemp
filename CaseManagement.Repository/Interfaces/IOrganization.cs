using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IOrganization
    {
        OrganizationDTOResponse List(string userName);

        OrganizationDTOResponse Deleted_List(string userName);

        DataUpdateResponseDTO Add(OrganizationDTOAddDB organizationDTOAddDB);

        DataUpdateResponseDTO Delete(int organizationId, string deletedBy, string deletedByIpAddress);

        DataUpdateResponseDTO Edit(OrganizationDTOEditDB organizationDTOEditDB);

        OrganizationDTODetailResponse Detail(int organizationId, string userName);

        OrganizationChangeLogDTOResponse ChangeLog_GetById(int organizationId, string userName);
    }
}