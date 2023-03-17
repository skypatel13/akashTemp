using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitPlanDimResponse
    {
        public DataUpdateResponseDTO dataUpdateResponseDTO { get; set; }
        public List<SurvivorCitPlanDimDTOList> SurvivorCitPlanDimDTOList { get; set; }
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
            status += $"Survivor CIT Plan Dimesion List Count:{this.SurvivorCitPlanDimDTOList.Count}";
            return status;
        }
    }
    public class SurvivorCitPlanDimDTOList 
    {
        public int SurAsmtDimCode { get; set; }
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public int Score { get; set; }
        public bool IsSelected { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
