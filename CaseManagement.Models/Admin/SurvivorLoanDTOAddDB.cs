using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLoanDTOAddDB
    {
        public int SurvivorCode { get; set; }
        public int TakenFromCode { get; set; }
        public string Purpose { get; set; }
        public int Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int ModeOfInterestCode { get; set; }
        public int RepaymentTenure { get; set; }
        public int RepaymentPerMonth { get; set; }
        public string ReferenceDocument { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public string MortgageData { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
