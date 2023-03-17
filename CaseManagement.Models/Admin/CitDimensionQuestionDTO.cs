﻿using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class CitDimensionQuestionDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<CitDimensionQuestionDTOList> CitDimensionQuestionDTOList { get; set; }

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
            status += $"CitDimensionQuestionDTOList Count:{CitDimensionQuestionDTOList.Count}";
            return status;
        }
    }

    public class CitDimensionQuestionDTOList
    {
        public int VersionDimensionQuestionCode { get; set; }
        public int VersionDimensionCode { get; set; }
        public int DimensionQuestionCode { get; set; }
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public string Question { get; set; }
        public string QuestionUIControlType { get; set; }
        public bool IsSelected { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}