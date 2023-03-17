using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class CitDimensionQuestionChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<CitDimensionQuestionChangeLogDTOList> CitDimensionQuestionChangeLogDTOList { get; set; }

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
            status += $"CitDimensionQuestionChangeLogDTOList Count:{CitDimensionQuestionChangeLogDTOList.Count}";
            return status;
        }
    }

    public class CitDimensionQuestionChangeLogDTOList
    {
        public int VersionDimensionQuestionCode { get; set; }
        public int VersionDimensionCode { get; set; }
        public string DimensionName { get; set; }
        public int DimensionQuestionCode { get; set; }
        public string Question { get; set; }
        public string QuestionUIControlType { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}