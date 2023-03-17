using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitActionDetailResponse
    {
        public DataUpdateResponseDTO dataUpdateResponse { get; set; }
        public SurvivorCitActionDTODetail survivorCitActionDTODetail { get; set; }
        public override string ToString()
        {
            if (this.dataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = dataUpdateResponse.ToString();
            if (this.dataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"Survivor Cit Action Detail :{this.survivorCitActionDTODetail}";
            return status;
        }
    }
    public class SurvivorCitActionDTODetail
    {
        public int SurAsmtActCode { get; set; }
        public int SurAsmtDimCode { get; set; }
        public string DimensionName { get; set; }
        public string Action { get; set; }
        public DateTime? TargetedDate { get; set; }
        public string IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string ClosedNotes { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string ClosedBy { get; set; }
        public string ClosedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
