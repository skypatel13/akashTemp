using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class RescueDTOEdit
    {
        public int RescueCode { get; set; }
        public int SurvivorCode { get; set; }
        public DateTime RescueDate { get; set; }
        public int RescuedStateCode { get; set; }
        public int RescuedDistrictCode { get; set; }
        public int? RescuedCityCode { get; set; }
        public string RescuedPlace { get; set; }
        public int? TypeOfPlaceCode { get; set; }
        public int RescuedByCode { get; set; }
        public int PoliceStationCode { get; set; }
        public string Notes { get; set; }
       
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
