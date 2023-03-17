using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IPoliceStation
    {
        PoliceStationDTOResponse List(string userName);

        PoliceStationDTOAddEditResult Add(PoliceStationDTOAddDB policeStationDTOAddDB);

        DataUpdateResponseDTO Delete(int policeStationCode, string deletedBy, string deletedByIpAddress);

        PoliceStationDTOAddEditResult Edit(PoliceStationDTOEditDB policeStationDTOEditDB);

        PoliceStationDTODetailResponse Detail(int policeStationCode, string userName);

        PoliceStationChangeLogDTOResponse ChangeLog_GetById(int policeStationCode, string userName);

        PoliceStationDTOResponse DeletedList(string userName);
    }
}
