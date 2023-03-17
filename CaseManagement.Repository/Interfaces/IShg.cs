using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IShg
    {
        ShgDTOResponse List(string userName);

        DataUpdateResponseDTO Add(ShgDTOAddDB collectiveDTOAddDB);

        DataUpdateResponseDTO Edit(ShgDTOEditDB collectiveDTOEditDB);

        SHGDTODetailResponse Detail(int shgCode, string userName);

        DataUpdateResponseDTO Delete(int shgCode, string deletedBy, string deletedByIpAddress);

        ShgDTOResponse DeletedList(string userName);

        ShgChangeLogDTOResponse ChangeLog_GetById(int sHGCode, string userName);
    }
}