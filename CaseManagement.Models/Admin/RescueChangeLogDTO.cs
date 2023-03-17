using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class RescueChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<RescueChangeLogDTOList> RescueChangeLogDTOList { get; set; }

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
            status += $"RescueChangeLogDTOList Count:{this.RescueChangeLogDTOList.Count}";
            return status;
        }
    }

    public class RescueChangeLogDTOList
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
        public int RescuedCityCode { get; set; }
        public string RescuedCity { get; set; }
        public int RescuedDistrictCode { get; set; }
        public string RescuedDistrict { get; set; }
        public string RescuedPlace { get; set; }
        public int TypeOfPlaceCode { get; set; }
        public string TypeOfPlace { get; set; }
        public int RescuedByCode { get; set; }
        public string RescuedBy { get; set; }
        public int PoliceStationCode { get; set; }
        public string PoliceStationName { get; set; }
        public string Notes { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public string IsDeleted { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}