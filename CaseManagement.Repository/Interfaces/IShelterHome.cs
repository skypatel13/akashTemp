using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IShelterHome
    {
        ShelterHomeDTOResponse List(string userName);

        ShelterHomeDTOAddEditResult Add(ShelterHomeDTOAddDB ShelterDTOAddDB);

        DataUpdateResponseDTO Delete(int shelterHomeCode, string deletedBy, string deletedByIpAddress);

        ShelterHomeDTOAddEditResult Edit(ShelterHomeDTOEditDB ShelterDTOEditDB);

        ShelterHomeDTODetailResponse Detail(int shelterHomeCode, string userName);

        ShelterHomeChangeLogDTOResponse ChangeLog_GetById(int shelterHomeCode, string userName);

        ShelterHomeDTOResponse DeletedList(string userName);

        ShelterHomeContactDTOResponse ContactList(string userName);

        ShelterHomeContactDTODetailResponse ContactDetail(int shelterHomeContactCode, string userName);

        ShelterHomeContactDTOAddEditResult ContactAdd(ShelterHomeContactDTOAddDB shelterHomeContactDTOAddDB);

        ShelterHomeContactDTOAddEditResult ContactEdit(ShelterHomeContactDTOEditDB shelterHomeContactDTOEditDB);

        DataUpdateResponseDTO ContactDelete(int shelterHomeContactCode, string deletedBy, string deletedByIpAddress);

        ShelterHomeContactDTOResponse ContactDeletedList(string userName);
        ShelterHomeContactChangeLogDTOResponse ContactChangeLog_GetById(int shelterHomeContactCode, string userName);
    }
}