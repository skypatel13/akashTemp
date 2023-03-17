using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorIncomeDetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorIncomeDTODetail survivorIncomeDTODetail { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!this.DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"Survivor Income Detail :{this.survivorIncomeDTODetail}";
            return status;
        }
    }
    public class SurvivorIncomeDTODetail
    {
        public int IncomeCode { get; set; }
        public int SurvivorCode { get; set; }
        public int ModeOfEarningCode { get; set; }
        public string ModeOfEarning { get; set; }
        public int Amount { get; set; }
        public int NatureOfWorkCode { get; set; }
        public string NatureOfWork { get; set; }
        public bool IsAvailableValue { get; set; }
        public string IsAvailableText { get; set; }
        public string IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
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
}
