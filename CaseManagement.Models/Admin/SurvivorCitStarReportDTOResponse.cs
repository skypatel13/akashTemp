using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitStarReportDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorCitDimensionDTOList> SurvivorCitDimensionList { get; set; }
        public List<SurvivorCitStarReportDTOList> SurvivorCitStarReportList { get; set; }
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
            status += $"Survivor CIT Dimension List Count:{this.SurvivorCitDimensionList.Count}";
            status += $"Survivor CIT Star Report List Count:{this.SurvivorCitStarReportList.Count}";
            return status;
        }
    }
    public class SurvivorCitDimensionDTOList
    {
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorCitStarReportDTOList 
    {
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public DateTime CitDate { get; set; }
        public int Score { get; set; }
        public bool IsApprovedValue { get; set; }
        public string IsApprovedText { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
