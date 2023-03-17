using CaseManagement.Models.Common;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLoanDeletedResponseDTO
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorLoanDTO> survivorLoansList { get; set; }
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
            status += $"Survivor Loan List Count:{this.survivorLoansList.Count}";
            return status;
        }
    }
}
