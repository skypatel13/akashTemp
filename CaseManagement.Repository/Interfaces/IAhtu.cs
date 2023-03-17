using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IAhtu
    {
        AhtuDTOResponse List(string userName);
        AhtuDTOAddEditResult Add(AhtuDTOAddDB ahtuDTOAddDB);

        DataUpdateResponseDTO Delete(int ahtuCode, string deletedBy, string deletedByIpAddress);

        AhtuDTOAddEditResult Edit(AhtuDTOEditDB ahtuDTOEditDB);

        AhtuDTODetailResponse Detail(int ahtuCode, string userName);

        AhtuChangeLogDTOResponse ChangeLog_GetById(int ahtuCode, string userName);

        AhtuDTOResponse DeletedList(string userName);

    }
}
