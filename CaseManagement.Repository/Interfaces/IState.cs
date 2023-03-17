using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IState
    {
        StateDTOResponse List(string userName);

        StateDTOResponse Deleted_List(string userName);

        DataUpdateResponseDTO Add(StateDTOAddDB stateDTOAddDB);

        DataUpdateResponseDTO Delete(int stateCode, string deletedBy, string deletedByIpAddress);

        StateDTODetailResponse Detail(int stateCode, string userName);

        DataUpdateResponseDTO Edit(StateDTOEditDB stateDTOEditDB);

        StateChangeLogDTOResponse ChangeLog_GetById(int stateCode, string userName);
    }
}