using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using System.Collections.Generic;

namespace CaseManagement.Repository.Interfaces
{
    public interface IDiary
    {
        DiaryDTOResponse List(string userName);
        List<DiaryDTOCalendar> CalendarList(string userName);

        DiaryDTODetailResponse Detail(string userName, int dailyDiaryId);

        DiaryDTOAddEditResult Add(DiaryDTOAddDB diaryDTOAddDB);

        DiaryDTOAddEditResult Edit(DiaryDTOEditDB diaryDTOEditDB);

        DataUpdateResponseDTO Delete(int dailyDiaryId, string deletedBy, string deletedByIpAddress);

        DiaryChangeLogDTOResponse ChangeLog_GetById(string userName, int dailyDiaryId);

        DiaryDTOResponse DeletedList(string userName);

        DiarySurvivorDTOResponse RelatedSurvivorList(string userName, int? dailyDiaryId);

        DiaryDTOAddEditResult StatusUpdate(DiaryDTOStatusUpdateDB diaryDTOStatusUpdateDB);

        DataUpdateResponseDTO ActionAdd(DiaryDTOActionAddDB diaryDTOActionAddDB);

        DiaryActionsDTOResponse Actions(string userName, int dailyDiaryId);

        DataUpdateResponseDTO Close(DiaryCloseDTOAddDB diaryCloseDTOAddDB);
        DataUpdateResponseDTO ActionDelete(int dailyDiaryActionsId, string deletedBy, string deletedByIpAddress);
    }
}