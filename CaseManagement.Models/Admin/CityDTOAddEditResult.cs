using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class CityDTOAddEditResult
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public CityDTODetail CityDTODetail { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"CityDTODetail :{this.CityDTODetail}";
            return status;
        }
    }
}
