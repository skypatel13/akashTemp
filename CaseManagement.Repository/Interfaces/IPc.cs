using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IPc
    {
        PcDTOResponse List(int survivorCode, string userName);
        PcDTOAddEditResult PCApplicationAdd(PcApplicationDTOAddDB lawyerDTOAddDB);

        PcDTOAddEditResult PCApplicationEdit(PcApplicationDTOEditDB pcDTOBasicEditDB);

        PcDTOAddEditResult OrderUpdate(PcDTOOrderEditDB pcDTOStatusEditDB);

        DataUpdateResponseDTO Delete(int pcCode, string deletedBy, string deletedByIpAddress);

        PcDTODetailResponse Detail(int pcCode, string userName);

        PcChangeLogDTOResponse ChangeLog_GetById(int pcCode, string userName);

        PcDTOResponse DeletedList(string userName, int survivorCode);

        PcEscalationDTOResponse EscalationList(string userName, int? pcCode);

        PcDTOAddEditResult EscalationAdd(PcEscalationDTOAddDB pcEscalationDTOAddDB);
        PcDTOAddEditResult concludedAdd(PcConcludeDTOAddDB pcConcludeDTOAddDB);
    }
}
