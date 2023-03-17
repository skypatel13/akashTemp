using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitActionResponse
    {
        public DataUpdateResponseDTO dataUpdateResponseDTO { get; set; }
        public List<SurvivorCitActionDTOList> survivorCitActionDTOLists { get; set; }
        public List<SurvivorCitSubActionListDTOList> survivorCitSubActionListDTOLists { get; set; }
        public List<SurvivorCitDimensionQuestion> survivorCitDimensionQuestions { get; set; }
        public List<SurvivorCitDimensionQuestionOption> survivorCitDimensionQuestionOptions { get; set; }
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
            status += $"Survivor CIT Action List Count:{this.survivorCitActionDTOLists.Count}";
            status += $"Survivor CIT Sub Action List Count:{this.survivorCitSubActionListDTOLists.Count}";
            status += $"Survivor CIT QuestionAnswer  List Count:{this.survivorCitDimensionQuestions.Count}";
            status += $"Survivor CIT QuestionOption List Count:{this.survivorCitDimensionQuestionOptions.Count}";
            return status;
        }
    }

    public class SurvivorCitActionDTOList
    {
        public int SurAsmtActCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public string Organization { get; set; }
        public int SurAsmtCode { get; set; }
        public int SurAsmtDimCode { get; set; }
        public int VersionDimensionCode { get; set; }
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public string Action { get; set; }
        public DateTime TargetedDate { get; set; }
        public DateTime CitDate { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class SurvivorCitSubActionListDTOList
    {
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public string Organization { get; set; }
        public int SurAsmtCode { get; set; }
        public int SurAsmtActCode { get; set; }
        public int SurAsmtSubActCode { get; set; }
        public string Action { get; set; }
        public string Activity { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public int DutyBearerCode { get; set; }
        public string DutyBearer { get; set; }
        public DateTime TargetedDate { get; set; }
        public DateTime CitDate { get; set; }
        public int VersionDimensionCode { get; set; }
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
