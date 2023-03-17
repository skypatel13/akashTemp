using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLoanDTOEdit
    {
        public int FinancialInclusionCode { get; set; }
        public int TakenFromCode { get; set; }
        public string Purpose { get; set; }
        public int Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int ModeOfInterestCode { get; set; }
        public int RepaymentTenure { get; set; }
        public int RepaymentPerMonth { get; set; }
        public IFormFile ReferenceDocument { get; set; }
        public Boolean IsReferenceDocumentChanged { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public string loanMortgageDTOLists { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
