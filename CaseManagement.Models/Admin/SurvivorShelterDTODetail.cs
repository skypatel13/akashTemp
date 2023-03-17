using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorShelterDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorShelterDTODetail survivorShelterDTODetail { get; set; }

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
            status += $"Survivor Shelter Detail :{survivorShelterDTODetail}";
            return status;
        }
    }
    public class SurvivorShelterDTODetail
    {
        public int SurvivorShelterHomeCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public int ShelterHomeCode { get; set; }
        public string ShelterHomeName { get; set; }
        public int SourceDestinationCode { get; set; }
        public string SourceDestination { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Notes { get; set; }
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
