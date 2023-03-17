using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLoanDTOPaidEditDB
    {
        public int FinancialInclusionPaidLogCode { get; set; }
        public int FinancialInclusionCode { get; set; }
        public DateTime PaidDate { get; set; }
        public int AmountPaid { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
