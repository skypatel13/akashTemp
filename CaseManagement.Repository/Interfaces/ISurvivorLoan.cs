using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Repository.Interfaces
{
    public interface ISurvivorLoan
    {
        SurvivorLoanResponse List(string userName, int? survivorCode);
        SurvivorLoanDTOAddEditResult Add(SurvivorLoanDTOAddDB survivorLoanDTOAddDB);
        SurvivorLoanDTOAddEditResult Edit(SurvivorLoanDTOEditDB survivorLoanDTOEditDB);
        SurvivorLoanDetailResponse Detail(int financialInclusionCode, string userName);
        DataUpdateResponseDTO Delete(int financialInclusionCode, string deletedBy, string deletedByIpAddress);
        SurvivorLoanPaidResponse PaidList(int financialInclusionCode, string userName);
        DataUpdateResponseDTO PaidInsert(SurvivorLoanDTOPaidAddDB survivorLoanDTOPaidAddDB);
        DataUpdateResponseDTO PaidEdit(SurvivorLoanDTOPaidEditDB survivorLoanDTOPaidEditDB);
        DataUpdateResponseDTO PaidDelete(int financialInclusionPaidLogCode, string deletedBy, string deletedByIpAddress);
        SurvivorLoanChangeLogResponse ChangeLog_GetById(int financialInclusionCode, string userName);
        SurvivorLoanDeletedResponseDTO DeletedList(string userName, int? survivorCode);

    }
}
