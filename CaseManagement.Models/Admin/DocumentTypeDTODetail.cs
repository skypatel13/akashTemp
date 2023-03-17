using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class DocumentTypeDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public DocumentTypeDTODetail DocumentTypeDTODetail { get; set; }

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
            status += $"DocumentTypeDTO Detail:{this.DocumentTypeDTODetail}";
            return status;
        }
    }

    public class DocumentTypeDTODetail
    {
        public int DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public string IsRequiredForSurvivorText { get; set; }
        public bool IsRequiredForSurvivorValue { get; set; }
        public bool IsSurvivorSpecificValue { get; set; }
        public string IsSurvivorSpecificText { get; set; }
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
