using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IPanchayat
    {
        PanchayatDTOResponse List(string userName);
        PanchayatDTOAddEditResult Add(PanchayatDTOAddDB panchayatDTOAddDB);
        PanchayatDTOAddEditResult Edit(PanchayatDTOEditDB panchayatDTOEditDB);
        DataUpdateResponseDTO Delete(int panchayatCode, string deletedBy, string deletedByIpAddress);
        PanchayatDTODetailResponse Detail(int panchayatCode, string userName);
        PanchayatDTOResponse DeletedList(string userName);
        PanchayatChangeLogDTOResponse ChangeLog_GetById(int panchayatCode, string userName);
    }
}
