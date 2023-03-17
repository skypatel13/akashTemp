using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorDTOList> SurvivorDTOList { get; set; }

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
            status += $"SurvivorDTOList Count:{this.SurvivorDTOList.Count}";
            return status;
        }
    }

    public class SurvivorDTOList
    {
        public int SurvivorCode { get; set; }
        public string Name { get; set; }
        public string AliasNames { get; set; }
        public int GenderCode { get; set; }
        public string Gender { get; set; }
        public int MaritalStatusCode { get; set; }
        public string MaritalStatus { get; set; }
        public int Children { get; set; }
        public string Address1 { get; set; }
        public string State { get; set; }
        public int StateCode { get; set; }
        public string District { get; set; }
        public int DistrictCode { get; set; }
        public string Block { get; set; }
        public int BlockCode { get; set; }
        public int VillageCode { get; set; }
        public string Village { get; set; }
        public int PanchayatCode { get; set; }
        public string Panchayat { get; set; }
        public string Pincode { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime TraffickingDate { get; set; }
        public int AgeWhenTrafficked { get; set; }
        public int PoliceStationCode { get; set; }
        public string PoliceStationName { get; set; }
        public int TafteeshStatusCode { get; set; }
        public string TafteeshStatus { get; set; }
        public int SurvivorTypeCode { get; set; }
        public string SurvivorType { get; set; }
        public string Photo { get; set; }
        public string PhotoStoredAsFileName { get; set; }
        public string ConsentForm { get; set; }
        public string ConsentFormStoredAsFileName { get; set; }
        public string Notes { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public int FamilyMembers { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string IsDeleted { get; set; }
        public int TafteeshStatusLogCode { get; set; }
        public string TafteeshStatusLog { get; set; }
        public string PartnerName { get; set; }
        public string SocialWorkerName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}