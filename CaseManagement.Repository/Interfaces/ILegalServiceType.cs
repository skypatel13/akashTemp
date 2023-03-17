using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ILegalServiceType
    {
        LegalServiceTypeDTOResponse List(string userName);

        LegalServiceTypeDTOAddEditResult Add(LegalServiceTypeDTOAddDB legalServiceTypeDTOAddDB);

        DataUpdateResponseDTO Delete(int legalServiceTypeCode, string deletedBy, string deletedByIpAddress);

        LegalServiceTypeDTOAddEditResult Edit(LegalServiceTypeDTOEditDB legalServiceTypeDTOEditDB);

        LegalServiceTypeDTODetailResponse Detail(int legalServiceTypeCode, string userName);

        LegalServiceTypeChangeLogDTOResponse ChangeLog_GetById(int legalServiceTypeCode, string userName);

        LegalServiceTypeDTOResponse DeletedList(string userName);
    }
}