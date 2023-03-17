using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{

    public class SurvivorLoanChangeLogResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorLoanChangeLogDTO> survivorLoanChangeLogDTOs { get; set; }
        public List<SurvivorPaidChangeLogDTO> survivorPaidChangeLogDTOs { get; set; }

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
            status += $"Survivor Loan ChangeLog List Count:{this.survivorLoanChangeLogDTOs.Count}";
            status += $"Survivor Loan Paid ChangeLog List Count:{this.survivorPaidChangeLogDTOs.Count}";
            return status;
        }
    }

    public class SurvivorLoanChangeLogDTO
    {
        public int FinancialInclusionCode { get; set; }
        public int SurvivorCode { get; set; }
        public int TakenFromCode { get; set; }
        public string TakenFrom { get; set; }
        public string Purpose { get; set; }
        public int Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int ModeOfInterestCode { get; set; }
        public string ModeOfInterest { get; set; }
        public int RepaymentTenure { get; set; }
        public int RepaymentPerMonth { get; set; }
        public string ReferenceDocument { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public int RemainingAmount { get; set; }
        public string IsDeleted { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorPaidChangeLogDTO
    {
        public int FinancialInclusionPaidLogCode { get; set; }
        public int FinancialInclusionCode { get; set; }
        public DateTime PaidDate { get; set; }
        public int AmountPaid { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
