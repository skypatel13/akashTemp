using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ICollective
    {
        DataUpdateResponseDTO Add(CollectiveDTOAddDB collectiveDTOAddDB);

        CollectiveChangeLogDTOResponse ChangeLog_GetById(int collectiveCode, string userName);

        DataUpdateResponseDTO Delete(int collectiveCode, string deletedBy, string deletedByIpAddress);

        CollectiveDTOResponse DeletedList(string userName);

        CollectiveDTODetailResponse Detail(int collectiveCode, string userName);

        DataUpdateResponseDTO Edit(CollectiveDTOEditDB collectiveDTOEditDB);

        CollectiveDTOResponse List(string userName);
    }
}