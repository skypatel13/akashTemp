using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class ChargeSheetDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public ChargeSheetDTODetail ChargeSheetDTODetail { get; set; }

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
            status += $"ChargeSheetDTODetail :{this.ChargeSheetDTODetail}";
            return status;
        }
    }
}
