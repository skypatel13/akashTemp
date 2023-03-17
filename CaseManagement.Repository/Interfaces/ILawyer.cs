using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ILawyer
    {
        LawyerDTOResponse List(string userName, int? survivorCode = 0);

        LawyerDTOAddEditResult Add(LawyerDTOAddDB lawyerDTOAddDB);

        DataUpdateResponseDTO Delete(int survivorLawyerCode, string deletedBy, string deletedByIpAddress);

        LawyerDTOAddEditResult Edit(LawyerDTOEditDB lawyerDTOEditDB);

        LawyerDTODetailResponse Detail(int survivorLawyerCode, string userName);

        LawyerChangeLogDTOResponse ChangeLog_GetById(int survivorLawyerCode, string userName);

        LawyerDTOResponse DeletedList(string userName);
        LawyerDTOListBySurvivorResponse LawyerListBySurvivorGetByCode(string userName, int survivorCode);
    }
}