using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IMember
    {
        MemberDTODetailResponse Detail(int memberCode, string userName);

        MemberDTOResponse List(string userName);

        MemberChangeLogDTOResponse ChangeLog_GetById(int memberCode, string userName);

        DataUpdateResponseDTO Delete(int memberCode, string deletedBy, string deletedByIpAddress);

        MemberDTOAddEditResult Add(MemberDTOAddDB memberDTOAddDB);

        MemberDTOAddEditResult Edit(MemberDTOEditDB memberDTOEditDB);

        MemberDTOResponse DeletedList(string userName);

        MemberLawyerDTOResponse MemberLawyerList(string userName);
        MemberSurvivorDTOResponse MemberSurvivorList(string userName, string memberId);
        DataUpdateResponseDTO MemberSurviviorAdd(MemberSurvivorDTOAddDB MemberSurvivorDTOAddDB);
        MemberSurvivorChangeLogDTOResponse MemberSurvivorChangeLog_GetById(string userName,int memberDataAccessCode);
        MemberCredentialDTOResponse MemberCredential_GetByCode_ForEmail(int memberCode, string userName);
    }
}