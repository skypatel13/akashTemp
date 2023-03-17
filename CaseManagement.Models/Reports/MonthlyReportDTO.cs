using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Reports
{
    public class MonthlyReportDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<MonthlyReportDTOList> MonthlyReportDTOList { get; set; }

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
            status += $"MonthlyReportDTOList Count:{MonthlyReportDTOList.Count}";
            return status;
        }
    }

    public class MonthlyReportDTOList
    {
        public int ScheduleMemberCode { get; set; }
        public string Duration { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}