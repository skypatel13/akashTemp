using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Reports
{
    public class PCRegisterResponse
    {
        public DataUpdateResponseDTO dataUpdateResponseDTO { get; set; }
        public List<dynamic> pcRegisterReports { get; set; }
        public override string ToString()
        {
            if (this.dataUpdateResponseDTO == null)
            {
                return $"No status available";
            }
            string status = dataUpdateResponseDTO.ToString();
            if (this.dataUpdateResponseDTO.Status == false)
            {
                return status;
            }
            status += $"PC Register Report Count:{this.pcRegisterReports.Count}";
            return status;
        }

    }
}
