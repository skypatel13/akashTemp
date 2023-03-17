using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IDimension
    {
        DimensionDTOResponse List(string userName);

        DimensionDTOAddEditResult Add(DimensionDTOAddDB dimensionDTOAddDB);

        DataUpdateResponseDTO Obsolete(int dimensionCode, string obsoleteBy, string obsoleteByByIpAddress);

        DimensionDTOAddEditResult Edit(DimensionDTOEditDB dimensionDTOEditDB);

        DimensionDTODetailResponse Detail(int dimensionCode, string userName);

        DimensionChangeLogDTOResponse ChangeLog_GetById(int dimensionCode, string userName);

        DimensionDTOResponse ObsoleteList(string userName);
    }
}