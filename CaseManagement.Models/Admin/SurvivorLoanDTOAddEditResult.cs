using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorLoanDTOAddEditResult
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
}
