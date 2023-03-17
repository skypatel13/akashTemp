using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ILawyerType
    {
        LawyerTypeDTOResponse List(string userName);

        LawyerTypeDTOAddEditResult Add(LawyerTypeDTOAddDB lawyerTypeDTOAddDB);
        LawyerTypeDTOAddEditResult Edit(LawyerTypeDTOEditDB lawyerTypeDTOEditDB);
        LawyerTypeDTODetailResponse Detail(int lawyerTypeCode, string userName);
        LawyerTypeChangeLogDTOResponse ChangeLog_GetById(int lawyerTypeCode, string userName);
        LawyerTypeDTOResponse DeletedList(string userName);
        DataUpdateResponseDTO Delete(int lawyerTypeCode, string deletedBy, string deletedByIpAddress);
    }
}