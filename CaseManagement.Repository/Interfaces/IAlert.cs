using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using CaseManagement.Models.Reports;

namespace CaseManagement.Repository.Interfaces
{
    public interface IAlert
    {
        AlertDTOResponse List(string userName);

        AlertSummaryDTOResponse SummaryList(string userName);

        AlertDTOAddEditResult MessageReadUpdate(int messageId, string modifiedBy, string modifiedByIpAddress);

        AlertDTODetailResponse Detail(int messageId, string userName);

        EmailDTODetailResponse EmailAdd(EmailDTOAdd emailDTOAdd);

        DataUpdateResponseDTO EmailUpdateIsReceived(EmailUpdateResponseDTO emailUpdateResponseDTO);
    }
}