using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SurvivorShelterChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorShelterChangeLogDTOList> survivorShelterChangeLogDTOLists { get; set; }

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
            status += $"Survivor Shelter ChangeLog Lists Count:{survivorShelterChangeLogDTOLists}";
            return status;
        }
    }
    public class SurvivorShelterChangeLogDTOList
    {
        public int SurvivorShelterHomeCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public int ShelterHomeNameCode { get; set; }
        public string ShelterHomeName { get; set; }
        public string SourceDestination { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
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
