using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorGrantChangeLogResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorGrantChangeLogDTO> survivorGrantChangeLogDTOs { get; set; }

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
            status += $"Survivor Grant ChangeLog DTOs List:{this.survivorGrantChangeLogDTOs.Count}";
            return status;
        }
    }
    public class SurvivorGrantChangeLogDTO
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
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
