using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IVillage
    {
        VillageDTOResponse List(string userName);
        VillageDTOAddEditResult Add(VillageDTOAddDB villageDTOAddDB);
        VillageDTOAddEditResult Edit(VillageDTOEditDB villageDTOEditDB);
        DataUpdateResponseDTO Delete(int villageCode, string deletedBy, string deletedByIpAddress);
        VillageDTODetailResponse Detail(int villageCode, string userName);
        VillageDTOResponse DeletedList(string userName);
        VillageChangeLogDTOResponse ChangeLog_GetById(int villageCode, string userName);
    }
}
