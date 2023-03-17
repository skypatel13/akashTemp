using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;

namespace CaseManagement.Repository.Interfaces
{
    public interface ISurvivorIncome
    {
        SurvirorIncomeResponse List(string userName, int? survivorCode);
        SurvivorIncomeDTOAddEditResult Add(SurvivorIncomeDTOAddDB survivorIncomeDTOAddDB);
        SurvivorIncomeDTOAddEditResult Edit(SurvivorIncomeDTOEditDB survivorIncomeDTOEditDB);
        SurvivorIncomeDetailResponse Detail(int incomeCode, string userName);
        DataUpdateResponseDTO Delete(int incomeCode, string deletedBy, string deletedByIpAddress);
        SurvirorIncomeResponse DeletedList(string userName, int? survivorCode);
        SurvirorIncomeResponseChangeLog ChangeLog_GetById(int incomeCode, string userName);
    }
}
