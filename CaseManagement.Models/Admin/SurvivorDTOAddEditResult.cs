using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorDTOAddEditResult
    {
         public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorDTODetail SurvivorDTODetail { get; set; }

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
            status += $" SurvivorDTODetail:{this.SurvivorDTODetail}";
            return status;
        }
    }
}
