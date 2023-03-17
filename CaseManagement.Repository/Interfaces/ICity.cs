using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Repository.Interfaces
{
    public interface ICity
    {
        CityDTOResponse List(string userName);
        CityDTOAddEditResult Add(CityDTOAddDB cityDTOAddDB);
        CityDTOAddEditResult Edit(CityDTOEditDB cityDTOEditDB);
        DataUpdateResponseDTO Delete(int cityCode, string deletedBy, string deletedByIpAddress);
        CityDTODetailResponse Detail(int cityCode, string userName);
        CityChangeLogDTOResponse ChangeLog_GetById(int CityCode, string userName);
        CityDTOResponse DeletedList(string userName);
    }
}
