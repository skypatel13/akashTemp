using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorDTOAdd
    {
        public string Name { get; set; }
        public string AliasNames { get; set; }
        public int GenderCode { get; set; }
        public int MaritalStatusCode { get; set; }
        public int Children { get; set; }
        public string Address1 { get; set; }
        public int StateCode { get; set; }
        public int DistrictCode { get; set; }
        public int BlockCode { get; set; }
        public int VillageCode { get; set; }
        public int PanchayatCode { get; set; }
        public string Pincode { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime TraffickingDate { get; set; }
        public int PoliceStationCode { get; set; }
        public string Notes { get; set; }
        //public int TafteeshStatusCode { get; set; }
        //public string TafteeshStatusNotes { get; set; }
        public IFormFile ConsentFormFile { get; set; }
        public int FamilyMembers { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}