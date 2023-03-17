using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLoanDTOPaidAddDB
    {
        public int FinancialInclusionCode { get; set; }
        public DateTime PaidDate { get; set; }
        public int AmountPaid { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
