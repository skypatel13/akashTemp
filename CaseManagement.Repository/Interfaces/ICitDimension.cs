using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ICitDimension
    {
        CitDimensionDTOResponse List(string userName,int? versionCode);

        DataUpdateResponseDTO Add(CitDimensionDTOAddDB versionDimensionDTOAddDB);

        CitDimensionDTODetailResponse Detail(int versionDimensionCode, string userName);

        CitDimensionChangeLogDTOResponse ChangeLog_GetById(int versionDimensionCode, string userName);

        CitDimensionQuestionDTOResponse QuestionList(string userName, int? versionDimensionCode);

        DataUpdateResponseDTO QuestionAdd(CitDimensionQuestionDTOAddDB versionDimensionQuestionDTOAddDB);

        CitDimensionQuestionChangeLogDTOResponse QuestionChangeLog_GetById(string userName, int versionDimensionQuestionCode);
    }
}