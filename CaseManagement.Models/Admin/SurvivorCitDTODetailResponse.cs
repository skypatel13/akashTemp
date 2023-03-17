using CaseManagement.Models.Common;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DimensionQuestionDTO
    {
        public int SurAsmtDimCode { get; set; }
        public int SurAsmtCode { get; set; }
        public int VersionDimensionCode { get; set; }
        public string DimensionName { get; set; }
        public int? Score { get; set; }
        public List<SurvivorCitDimensionQuestion> survivorCitDimensionQuestions { get; set; }
        public List<CitDeptDutyBearerDTOList> deptDutyBearerDTOLists { get; set; }  
    }
    public class QuestionOptionsDTO
    {
        public int SurAsmtDimQueCode { get; set; }
        public List<SurvivorCitDimensionQuestionOption> survivorCitDimensionQuestionOptions { get; set; }
    }

    public class SurvivorCitDTODetailResponse
    {
        public DataUpdateResponseDTO dataUpdateResponseDTO { get; set; }
        public SurvivorCitDTODetail survivorCitDTODetail { get; set; }
        public List<SurvivorCitDimension> survivorCitDimension { get; set; }
        public List<SurvivorCitDimensionQuestion> survivorCitDimensionQuestions { get; set; }
        public List<SurvivorCitDimensionQuestionOption> survivorCitDimensionQuestionOptions { get; set; }
        public List<SurvivorCitActionDTOList> survivorCitActionDTOLists { get; set; }
        public List<SurvivorCitSubActionListDTOList> survivorCitSubActionListDTOLists { get; set; }
        public List<DimensionQuestionDTO> dimensionQuestionDTOs { get; set; }
        public List<QuestionOptionsDTO> questionOptionsDTOs { get; set; }
        public List<CitDeptDutyBearerDTOList> deptDutyBearerDTOLists { get; set; }
        public List<CitStatusLogDTO> CitStatusLogDTO { get; set; }
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
            status += $"Survivor Cit Department and Duty Bearer List :{this.deptDutyBearerDTOLists}";
            status += $"Survivor Cit CitStatusLogDTO Count:{this.CitStatusLogDTO};";
            return status;
        }

    }
}
