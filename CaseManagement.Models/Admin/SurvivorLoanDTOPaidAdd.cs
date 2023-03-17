using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLoanDTOPaidAdd
    {
        public int FinancialInclusionCode { get; set; }
        public DateTime PaidDate { get; set; }
        public int AmountPaid { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
