using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface IVc
    {
        VcDTOResponse List(string userName, int survivorCode);

        VcDTOAddEditResult VCApplicationAdd(VcApplicationDTOAddDB lawyerDTOAddDB);

        VcDTOAddEditResult VCApplicationEdit(VcApplicationDTOEditDB vcDTOBasicEditDB);

        VcDTOAddEditResult OrderUpdate(VcDTOOrderEditDB vcDTOStatusEditDB);

        DataUpdateResponseDTO Delete(int vcCode, string deletedBy, string deletedByIpAddress);

        VcDTODetailResponse Detail(int vcCode, string userName);

        VcChangeLogDTOResponse ChangeLog_GetById(int vcCode, string userName);

        VcDTOResponse DeletedList(string userName, int survivorCode);

        VcEscalationDTOResponse EscalationList(string userName, int? vcCode);

        VcDTOAddEditResult EscalationAdd(VcEscalationDTOAddDB vcEscalationDTOAddDB);

        VcDTOAddEditResult concludedAdd(VCConcludeDTOAddDB vCConcludeDTOAddDB);
        VcDTODetailResponse BankDetailUpdate(VcBankDetailDTOAddDB vcBankDetailDTOAddDB);
    }
}