using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class DimensionQuestionDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DimensionQuestionDTOList> DimensionQuestionDTOList { get; set; }
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
            status += $"DimensionQuestionDTOList Count:{DimensionQuestionDTOList.Count}";
            return status;
        }
    }
    public class DimensionQuestionDTOList
    {
        public int DimensionQuestionCode { get; set; }
        public string Question { get; set; }
        public int QuestionUIControlTypeCode { get; set; }
        public string QuestionUIControlType { get; set; }
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}