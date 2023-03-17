using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IAct
    {
        ActDTOResponse List(string userName);

        ActDTOAddEditResult Add(ActDTOAddDB actDTOAddDB);

        DataUpdateResponseDTO Delete(int actCode, string deletedBy, string deletedByIpAddress);

        ActDTOAddEditResult Edit(ActDTOEditDB actDTOEditDB);

        ActDetailResponse Detail(int actCode, string userName);

        ActChangeLogDTOResponse ChangeLog_GetById(int actCode, string userName);

        ActDTOResponse DeletedList(string userName);
    }
}