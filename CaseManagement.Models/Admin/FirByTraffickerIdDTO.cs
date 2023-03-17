using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class FirTraffickerResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SurvivorTraffickerHeader survivorTraffickerHeaders { get; set; }
        public List<FirByTraffickerIdDTO> firByTraffickerIdList { get; set; }

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
            status += $"FirByTraffickerIdDTO Count :{this.firByTraffickerIdList.Count}";
            return status;
        }
    }

    public class FirByTraffickerIdDTO
    {
        public int TraffickerCode { get; set; }
        public string TraffickerId { get; set; }
        public string TraffickerName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Alias { get; set; }
        public string IdentificationMark { get; set; }
        public int FIRCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public string SourceDestination { get; set; }
        public int PoliceStationCode { get; set; }
        public string PoliceStationName { get; set; }
        public string DeFactoComplainer { get; set; }
        public int NumberOfAccused { get; set; }
        public string GDNumber { get; set; }
        public string FIRNumber { get; set; }
        public DateTime FIRDate { get; set; }
        public string Sections { get; set; }
        public string Traffickers { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}