using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ICitTemplate
    {
        CitTemplateDTOResponse List(string userName);

        CitTemplateDTOAddEditResult Add(CitTemplateDTOAddDB versionDTOAddDB);

        DataUpdateResponseDTO Obsolete(int versionCode, string obsoleteBy, string obsoleteByByIpAddress);

        CitTemplateDTOAddEditResult Edit(CitTemplateDTOEditDB versionDTOEditDB);

        CitDTODetailResponse Detail(int versionCode, string userName);

        CitChangeLogDTOResponse ChangeLog_GetById(int versionCode, string userName);

        CitTemplateDTOResponse ObsoleteList(string userName);
    }
}