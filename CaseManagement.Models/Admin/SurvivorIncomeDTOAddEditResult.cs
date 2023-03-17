using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorIncomeDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorIncomeDTODetail survivorIncomeDTODetail { get; set; }

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
            status += $"Survivor Income Detail :{this.survivorIncomeDTODetail}";
            return status;
        }
    }
}
