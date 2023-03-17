using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ISurvivorGrant
    {
        SurvivorGrantResponse List(int survivorCode, string userName);
        SurvivorGrantDTOAddEditResult Add(SurvivorGrantDTOAddDB survivorGrantDTOAddDB);
        SurvivorGrantDTOAddEditResult Edit(SurvivorGrantDTOEditDB survivorGrantDTOEditDB);
        SurvivorGrantDTOAddEditResult orderEdit(SurvivorGrantOrderEditDB survivorGrantOrderEditDB);
        SurvivorGrantDetailResponse Detail(int grantCode, string userName);
        DataUpdateResponseDTO Delete(int grantCode, string deletedBy, string deletedByIpAddress);
        SurvivorGrantChangeLogResponse ChangeLog_GetById(int grantCode, string userName);
        SurvivorGrantResponse DeletedList(int survivorCode, string userName);
    }
}
