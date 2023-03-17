using CaseManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitSubActionResponse
    {
        public DataUpdateResponseDTO dataUpdateResponseDTO { get; set; }
        public List<SurvivorCitSubActionListDTOList> survivorCitSubActionListDTOLists { get; set; }
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
            status += $"Survivor CIT Sub Action List Count:{this.survivorCitSubActionListDTOLists.Count}";
            return status;
        }
    }
}
