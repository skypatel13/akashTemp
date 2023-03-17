using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ISurvivor
    {
        SurvivorDTOResponse List(string userName);
        SurvivorDTOAddEditResult Add(SurvivorDTOAddDB survivorDTOAddDB);
        DataUpdateResponseDTO Delete(int survivorCode, string deletedBy, string deletedByIpAddress);
        SurvivorDTOAddEditResult Edit(SurvivorDTOEditDB survivorDTOEditDB);
        SurvivorDTODetailResponse Detail(int survivorCode, string userName);
        SurvivorDTOResponse DeletedList(string userName);
        SurvivorChangeLogDTOResponse ChangeLog_GetById(int survivorCode, string userName);
        DataUpdateResponseDTO ProfileStatusUpdate(SurvivorProfileApproveRequestDTODB SurvivorProfileApproveRequestDTODB);
        DataUpdateResponseDTO TafteeshStatusUpdate(SurvivorTafteeshStatusRequestDTODB survivorTafteeshStatusRequestDTODB);
        DataUpdateResponseDTO SurvivorStatus_Insert_Admin(TafteeshStatusRequestDTODB TafteeshStatusRequestDTODB);
        DataUpdateResponseDTO SurvivorStatus_Update_Admin(TafteeshStatusResponseDTODB TafteeshStatusResponseDTODB);
        TafteeshStatusLogDTOResponse SurvivorStatus_ListByCode(int survivorCode, string userName);
        SurvivorProfileReportDTOResponse SurvivorProfileDetailsByCode(int survivorCode, string userName);
    }
}