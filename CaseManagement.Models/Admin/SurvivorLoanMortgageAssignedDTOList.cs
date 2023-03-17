using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLoanMortgageAssignedDTOList
    {
        public int FinancialInclusionMortgageCode { get; set; }
        public int FinancialInclusionCode { get; set; }
        public int MortgageCode { get; set; }
        public string Mortgage { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
