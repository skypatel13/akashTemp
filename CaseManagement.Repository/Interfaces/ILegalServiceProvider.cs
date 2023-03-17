using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ILegalServiceProvider
    {
        LegalServiceProviderDTOResponse List(string userName);

        LegalServiceProviderDTOAddEditResult Add(LegalServiceProviderDTOAddDB legalServiceProviderDTOAddDB);

        DataUpdateResponseDTO Delete(int legalServiceProviderCode, string deletedBy, string deletedByIpAddress);

        LegalServiceProviderDTOAddEditResult Edit(LegalServiceProviderDTOEditDB legalServiceProviderDTOEditDB);

        LegalServiceProviderDTODetailResponse Detail(int legalServiceProviderCode, string userName);

        LegalServiceProviderChangeLogDTOResponse ChangeLog_GetById(int legalServiceProviderCode, string userName);

        LegalServiceProviderDTOResponse DeletedList(string userName);
    }
}