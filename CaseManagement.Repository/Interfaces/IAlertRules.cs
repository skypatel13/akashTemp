using CaseManagement.Models.Admin;
using CaseManagement.Models.Reports;

namespace CaseManagement.Repository.Interfaces
{
    public interface IAlertRules
    {
        AlertRuleDTOResponse List(string userName);
        AlertRuleDTODetailResponse Detail(int rulesId, string userName);
    }
}
