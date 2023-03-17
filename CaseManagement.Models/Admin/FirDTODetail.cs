using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class FirDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public FirDTODetail FirDTODetail { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!this.DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"FirDTODetail :{this.FirDTODetail}";
            return status;
        }
    }

    public class FirDTODetail
    {
        public int FIRCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public int SourceDestinationCode { get; set; }
        public string SourceDestination { get; set; }
        public int PoliceStationCode { get; set; }
        public string PoliceStationName { get; set; }
        public string DeFactoComplainer { get; set; }
        public int NumberOfAccused { get; set; }
        public int RelationCode { get; set; }
        public string Relation { get; set; }
        public string GDNumber { get; set; }
        public DateTime? GDDate { get; set; }
        public string GDIssue { get; set; }
        public string FIRNumber { get; set; }
        public DateTime FIRDate { get; set; }
        public string FIRIssue { get; set; }
        public string FIRCopy { get; set; }
        public string FIRCopyStoredAs { get; set; }
        public string GDCopy { get; set; }
        public string GDCopyStoredAs { get; set; }
        public string Sections { get; set; }
        public string Traffickers { get; set; }
        public List<FirAssignedAccusedDTOList> FirAssignedAccusedDTOList { get; set; }
        public List<FirAssignedActSectionDTOList> FirAssignedActSectionDTOList { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}