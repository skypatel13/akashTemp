using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IDistrict
    {
        DistrictDTOResponse List(string userName);

        DataUpdateResponseDTO Add(DistrictDTOAddDB districtDTOAddDB);

        DataUpdateResponseDTO Edit(DistrictDTOEditDB districtDTOEditDB);

        DataUpdateResponseDTO Delete(int districtCode, string deletedBy, string deletedByIpAddress);

        DistrictDTOResponse DeletedList(string userName);

        DistrictDTODetailResponse Detail(int districtCode, string userName);

        DistrictChangeLogDTOResponse ChangeLog_GetById(int districtCode, string userName);
    }
}