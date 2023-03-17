using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLoanDetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorLoanDTODetail survivorLoanDTODetail { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!this.DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"Survivor Loan Detail :{this.survivorLoanDTODetail}";
            return status;
        }
    }
    public class SurvivorLoanDTODetail
    {
        public int FinancialInclusionCode { get; set; }
        public int SurvivorCode { get; set; }
        public int TakenFromCode { get; set; }
        public string TakenFrom { get; set; }
        public string Purpose { get; set; }
        public int Amount { get; set; }
        public int AmountPaid { get; set; }
        public decimal InterestRate { get; set; }
        public int ModeOfInterestCode { get; set; }
        public string ModeOfInterest { get; set; }
        public int RepaymentTenure { get; set; }
        public int RepaymentPerMonth { get; set; }
        public string ReferenceDocument { get; set; }
        public string ReferenceDocumentStoredAs { get; set; }
        public List<SurvivorLoanMortgageAssignedDTOList> survivorLoanMortgageAssignedDTOLists { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public int RemainingAmount { get; set; }
        public string IsDeleted { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
