using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceTypeDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LegalServiceTypeDTOList> LegalServiceTypeDTOList { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"LegalServiceTypeDTOList Count:{this.LegalServiceTypeDTOList.Count}";
            return status;
        }
    }

    public class LegalServiceTypeDTOList
    {
        public int LegalServiceTypeCode { get; set; }
        public string LegalServiceTypeId { get; set; }
        public string LegalServiceTypeName { get; set; }
        public string ProgramAxis { get; set; }
        public int AuthorityLevelCode { get; set; }
        public string AuthorityLevel { get; set; }
        public Boolean IsCourtValue { get; set; }
        public string IsCourtText { get; set; }
        public string Notes { get; set; }
        public string IsDeleted { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}