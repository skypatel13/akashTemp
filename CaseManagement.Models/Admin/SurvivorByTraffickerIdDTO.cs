using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorTraffickerResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorTraffickerHeader survivorTraffickerHeaders { get; set; }
        public List<SurvivorListByTraffickerIdDTO> survivorListByTraffickerId { get; set; }
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
            status += $"SurvivorTraffickerHeader :{this.survivorTraffickerHeaders}";
            status += $"SurvivorListByTraffickerIdDTO Count :{this.survivorListByTraffickerId.Count}";
            return status;
        }
    }

    public class SurvivorListByTraffickerIdDTO
    {
        public string TraffickerId { get; set; }
        public string TraffickerName { get; set; }
        public string TraffickerGender { get; set; }
        public string Alias { get; set; }
        public string IdentificationMark { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string SurvivorGender { get; set; }
        public string MaritalStatus { get; set; }
        public int Children { get; set; }
        public int FamilyMembers { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string Address1 { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string Village { get; set; }
        public string Panchayat { get; set; }
        public string Pincode { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime TraffickingDate { get; set; }
        public int AgeWhenTrafficked { get; set; }
        public string PoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string Relation { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
