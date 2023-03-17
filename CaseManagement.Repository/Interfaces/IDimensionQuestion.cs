using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IDimensionQuestion
    {
        DimensionQuestionDTOResponse List(string userName);
        DimensionQuestionDTOAddEditResult Add(DimensionQuestionDTOAddDB dimensionQuestionDTOAddDB);
        DimensionQuestionDTOAddEditResult Edit(DimensionQuestionDTOEditDB dimensionQuestionDTOEditDB);
        DataUpdateResponseDTO Delete(int dimensionQuestionCode, string deletedBy, string deletedByIpAddress);
        QuestionDTODetailResponse Detail(int dimensionQuestionCode, string userName);
        DimensionQuestionChangeLogDTOResponse ChangeLog_GetById(int dimensionQuestionCode, string userName);
        DimensionQuestionDTOResponse DeletedList(string userName);
    }
}
