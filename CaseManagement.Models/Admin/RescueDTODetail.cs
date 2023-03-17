using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class RescueDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public RescueDTODetail RescueDTODetail { get; set; }

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
            status += $"RescueDTODetail :{this.RescueDTODetail}";
            return status;
        }
    }

    public class RescueDTODetail
    {
        public int RescueCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string SurvivorPoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public DateTime RescueDate { get; set; }
        public int AgeWhenRescue { get; set; }
        public int AgeWhenTrafficked { get; set; }
        public int RescuedStateCode { get; set; }
        public string RescuedState { get; set; }
        public int RescuedDistrictCode { get; set; }
        public string RescuedDistrict { get; set; }
        public int RescuedCityCode { get; set; }
        public string RescuedCity { get; set; }
        public string RescuedPlace { get; set; }
        public int TypeOfPlaceCode { get; set; }
        public string TypeOfPlace { get; set; }
        public int RescuedByCode { get; set; }
        public string RescuedBy { get; set; }
        public int PoliceStationCode { get; set; }
        public string PoliceStationName { get; set; }
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