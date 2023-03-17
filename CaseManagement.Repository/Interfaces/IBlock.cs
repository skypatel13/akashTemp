using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IBlock
    {
        BlockDTOListResponse List(string userName);

        DataUpdateResponseDTO Add(BlockDTOAddDB blockDTOAddDB);

        DataUpdateResponseDTO Edit(BlockDTOEditDB blockDTOEditDB);

        BlockDetailResponse Detail(int blockCode, string userName);

        DataUpdateResponseDTO Delete(int blockCode, string deletedBy, string deletedByIpAddress);

        BlockDTOListResponse DeletedList(string userName);

        //BlockDTOListGetByDistrictResponse GetByDistrictId(int districtId, string userName);

        BlockChangeLogDTOResponse ChangeLog_GetById(int blockCode, string userName);
    }
}