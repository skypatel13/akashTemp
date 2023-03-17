using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;


namespace CaseManagement.Repository.Interfaces
{
    public interface ITrafficker
    {
        TraffickerDTOResponse List(string userName);
        TraffickerDTOAddEditResult Add(TraffickerDTOAddDB traffickerDTOAddDB);
        DataUpdateResponseDTO Delete(int traffickerCode, string deletedBy, string deletedByIpAddress);
        TraffickerDTOAddEditResult Edit(TraffickerDTOEditDB traffickerDTOEditDB);
        TraffickerDTODetailResponse Detail(int traffickerCode, string userName);
        SurvivorTraffickerResponse survivorTraffickerResponse(string traffickerId, string userName);
        FirTraffickerResponse firTraffickerResponse(string traffickerId, string userName);
        TraffickerStatusResponse traffickerStatusResponse(TraffickerStatusDTOAddDB traffickerStatusDTOAddDB);
        DataUpdateResponseDTO traffickerStatusDelete(int traffickerStatusLogCode, string deletedBy, string deletedByIpAddress);
        TraffickerChangeLogDTOResponse ChangeLog_GetById(int traffickerCode, string userName);
        TraffickerDTOResponse DeletedList(string userName);
    }
}
