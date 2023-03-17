using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ISurvivorTrafficker
    {
        SurvivorTraffickerDTOResponse List(string userName, int? survivorCode);
        DataUpdateResponseDTO Add(SurvivorTraffickerDTOAddDB survivorTraffickerDTOAddDB);
        DataUpdateResponseDTO AddRelation(SurvivorTraffickerRelationDTOAddDB survivorTraffickerRelationDTOAddDB);
        DataUpdateResponseDTO DeleteRelation(int traffickerRelationCode, string deletedBy, string deletedByIpAddress);
        SurvivorTraffickerChangeLogDTOResponse ChangeLog_GetById(int survivorCode, string userName);
    }
}