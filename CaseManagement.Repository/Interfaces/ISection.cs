using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ISection
    {
        SectionDTOResponse List(string userName);

        SectionDTOAddEditResult Add(SectionDTOAddDB actSectionDTOAddDB);

        SectionDTOAddEditResult Edit(SectionDTOEditDB actSectionDTOEditDB);

        DataUpdateResponseDTO Delete(int actSectionCode, string deletedBy, string deletedByIpAddress);

        SectionDTODetailResponse Detail(int actSectionCode, string userName);

        SectionLogDTOResponse ChangeLog_GetById(int actSectionCode, string userName);

        SectionDTOResponse DeletedList(string userName);
    }
}