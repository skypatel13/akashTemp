using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLoanPaidResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorLoanPaidDTO> survivorLoanPaidList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"Survivor Loan Paid List Count:{this.survivorLoanPaidList.Count}";
            return status;
        }
    }
    public class SurvivorLoanPaidDTO
    {
        public int FinancialInclusionCode { get; set; }
        public int SurvivorCode { get; set; }
        public string TakenFrom { get; set; }
        public string Purpose { get; set; }
        public decimal InterestRate { get; set; }
        public string ModeOfInterest { get; set; }
        public int FinancialInclusionPaidLogCode { get; set; }
        public DateTime PaidDate { get; set; }
        public int AmountPaid { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
