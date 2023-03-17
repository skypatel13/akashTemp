using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorDTOEditDB
    {
        public int SurvivorCode { get; set; }
        public string Name { get; set; }
        public string AliasNames { get; set; }
        public int GenderCode { get; set; }
        public int MaritalStatusCode { get; set; }
        public int Children { get; set; }
        public string Address1 { get; set; }
        public int StateCode { get; set; }
        public int DistrictCode { get; set; }
        public int BlockCode { get; set; }
        public int? VillageCode { get; set; }
        public int? PanchayatCode { get; set; }
        public string Pincode { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime TraffickingDate { get; set; }
        public int PoliceStationCode { get; set; }
        public string SHGXML { get; set; }
        public string CollectiveXML { get; set; }
        public int FamilyMembers { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string Notes { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
