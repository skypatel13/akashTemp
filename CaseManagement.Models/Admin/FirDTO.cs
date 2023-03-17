using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class FirDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<FirDTOList> FirDTOList { get; set; }
        public List<FirAssignedActSectionDTOList> FirAssignedActSectionDTOList { get; set; }
        public List<FirAssignedAccusedDTOList> FirAssignedAccusedDTOList { get; set; }

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
            status += $"FirDTOList Count:{this.FirDTOList.Count}";
            status += $"FirAssignedActSectionDTOList Count:{this.FirAssignedActSectionDTOList.Count}";
            status += $"FirAssignedAccusedDTOList Count:{this.FirAssignedAccusedDTOList.Count}";
            return status;
        }
    }

    public class FirDTOList
    {
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
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
        public int InvestigationCount { get; set; }
        public string IsDeleted { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}