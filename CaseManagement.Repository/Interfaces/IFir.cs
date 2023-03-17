using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IFir
    {
        FirDTOResponse List(string userName);

        FirDTOAddEditResult Add(FirDTOAddDB FirDTOAddDB);

        DataUpdateResponseDTO Delete(int FirCode, string deletedBy, string deletedByIpAddress);

        FirDTOAddEditResult Edit(FirDTOEditDB FirDTOEditDB);

        FirDTODetailResponse Detail(int FirCode, string userName);

        FirBasicDetailDTOResponse BasicDetail(int FirCode, string userName);

        FirChangeLogDTOResponse ChangeLog_GetById(int FirCode, string userName);

        FirAccusedDTOResponse GetFirAccusedList(int FirCode, string userName);

        FirActSectionDTOResponse GetFirActSectionList(int FirCode, string userName);

        FirDTOResponse DeletedList(string userName);

        FirDTOResponse ListBySurvivor(string userName, int survivorCode);

        FirDTOResponse DeletedListBySurvivor(string userName, int survivorCode);

        DataUpdateResponseDTO ActSectionAdd(FirActSectionRequestDTODB firActSectionRequestDTODB);
        SurvivorPoliceStationSourceDestinationDTOResponse GetPoliceStationBySourceDestination(string userName,int survivorCode );
    }
}