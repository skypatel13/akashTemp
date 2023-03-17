using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLoanDTOPaidEdit
    {
        public int FinancialInclusionPaidLogCode { get; set; }
        public int FinancialInclusionCode { get; set; }
        public DateTime PaidDate { get; set; }
        public int AmountPaid { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
