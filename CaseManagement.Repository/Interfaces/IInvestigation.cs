using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IInvestigation
    {
        InvestigationDTOResponse List(string userName, int survivorCode);

        InvestigationDTOAddEditResult Add(InvestigationDTOAddDB investigationDTOAddDB);

        DataUpdateResponseDTO Delete(int investigationCode, string deletedBy, string deletedByIpAddress);

        InvestigationDTOAddEditResult Edit(InvestigationDTOEditDB investigationDTOEditDB);

        InvestigationDTODetailResponse Detail(int investigationCode, string userName);

        InvestigationChangeLogDTOResponse ChangeLog_GetById(int investigationCode, string userName);

        InvestigationDTOResponse DeletedList(string userName,int survivorCode);

        InvestigationDTOAddEditResult OfficerChange(InvestigationOfficerChangeDTOAddDB investigationOfficerChangeDTOAddDB);

        InvestigationDTOAddEditResult AgencyChange(InvestigationAgencyChangeDTOAddDB investigationAgencyChangeDTOAddDB);

        InvestigationDTOAddEditResult StatusChange(InvestigationStatusChangeDTOAddDB investigationStatusChangeDTOAddDB);

        InvestigationDTOAddEditResult Acceptance(InvestigationAcceptanceDTOUpdateDB investigationAcceptanceDTOUpdateDB);
    }
}