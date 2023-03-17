using CaseManagement.Models.Common;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitDTOAddEditResult
    {
        public DataUpdateResponseDTO dataUpdateResponseDTO { get; set; }
        public SurvivorCitDTODetail survivorCitDTODetail { get; set; }
        public List<SurvivorCitDimension> survivorCitDimension { get; set; }
        public List<SurvivorCitDimensionQuestion> survivorCitDimensionQuestions { get; set; }
        public List<SurvivorCitDimensionQuestionOption> survivorCitDimensionQuestionOptions { get; set; }
        public List<SurvivorCitActionDTOList> survivorCitActionDTOLists { get; set; }
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
            status += $"Survivor Cit Detail :{this.survivorCitDTODetail}";
            status += $"Survivor Cit Dimension :{this.survivorCitDimension}";
            status += $"Survivor Cit Dimension Question :{this.survivorCitDimensionQuestions}";
            status += $"Survivor Cit Dimension Question Option :{this.survivorCitDimensionQuestionOptions}";
            status += $"Survivor Cit Action List :{this.survivorCitActionDTOLists}";
            return status;
        }

    }
}
