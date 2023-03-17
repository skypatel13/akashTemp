using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorGrantResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorGrantDTO> survivorGrantDTOs { get; set; }

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
            status += $"Survivor Grant List Count:{this.survivorGrantDTOs.Count}";
            return status;
        }
    }
    public class SurvivorGrantDTO
    {
        public int GrantCode { get; set; }
        public int SurvivorCode { get; set; }
        public string Name { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Purpose { get; set; }
        public string ApplicationNumber { get; set; }
        public int AmountClaimed { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public int ResultCode { get; set; }
        public string Result { get; set; }
        public DateTime OrderDate { get; set; }
        public int AmountAwarded { get; set; }
        public bool IsEscalation { get; set; }
        public string EscalationReason { get; set; }
        public int Installments { get; set; }
        public string AliasName { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
