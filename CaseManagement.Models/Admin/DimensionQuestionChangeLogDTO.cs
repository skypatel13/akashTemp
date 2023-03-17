using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class DimensionQuestionChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DimensionQuestionChangeLogDTOList> DimensionQuestionChangeLogDTOList { get; set; }
        public List<DimensionQuestionOptionChangeLogDTOList> DimensionQuestionOptionChangeLogDTOList { get; set; }
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
            status += $"DimensionQuestionChangeLogDTOList Count:{DimensionQuestionChangeLogDTOList.Count}";
            if (this.DimensionQuestionOptionChangeLogDTOList != null)
                status += $"DimensionQuestionOptionChangeLogDTOList Count:{DimensionQuestionOptionChangeLogDTOList.Count}";
            return status;
        }
    }
    public class DimensionQuestionChangeLogDTOList
    {
        public int DimensionQuestionCode { get; set; }
        public string Question { get; set; }
        public int QuestionUIControlTypeCode { get; set; }
        public string QuestionUIControlType { get; set; }
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class DimensionQuestionOptionChangeLogDTOList
    {
        public int DimensionQuestionCode { get; set; }
        public string OptionValue { get; set; }
        public string OptionText { get; set; }
        public string IsDeleted { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}


