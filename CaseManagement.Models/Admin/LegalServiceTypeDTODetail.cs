using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceTypeDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public LegalServiceTypeDTODetail LegalServiceTypeDTODetail { get; set; }

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
            status += $"LegalServiceTypeDTODetail :{this.LegalServiceTypeDTODetail}";
            return status;
        }
    }

    public class LegalServiceTypeDTODetail
    {
        public int LegalServiceTypeCode { get; set; }
        public string LegalServiceTypeId { get; set; }
        public string LegalServiceTypeName { get; set; }
        public List<LegalServiceTypeAssignedProgramAxis> ProgramAxis { get; set; }
        public int AuthorityLevelCode { get; set; }
        public string AuthorityLevel { get; set; }
        public Boolean IsCourtValue { get; set; }
        public string IsCourtText { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}