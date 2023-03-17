using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class QuestionDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public DimensionQuestionDTODetail DimensionQuestionDTODetail { get; set; }
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
            status += $"DimensionQuestionDTODetail :{DimensionQuestionDTODetail}";
            return status;
        }
    }
    public class DimensionQuestionDTODetail
    {
        public int DimensionQuestionCode { get; set; }
        public string Question { get; set; }
        public int QuestionUIControlTypeCode { get; set; }
        public string QuestionUIControlType { get; set; }
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public List<DimensionQuestionOptionDTOList> DimensionQuestionOptionDTOList { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class DimensionQuestionOptionDTOList
    {
        public int DimensionQuestionOptionCode { get; set; }
        public int DimensionQuestionCode { get; set; }
        public string OptionValue { get; set; }
        public string OptionText { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}
