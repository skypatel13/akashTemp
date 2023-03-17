using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class FirChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<FirChangeLogDTOList> FirChangeLogDTOList { get; set; }
        public List<ActSectionChangeLogDTOList> ActSectionChangeLogDTOList { get; set; }
        public List<AccusedChangeLogDTOList> AccusedChangeLogDTOList { get; set; }

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
            status += $"FirChangeLogDTOList Count:{this.FirChangeLogDTOList.Count}";
            status += $"ActSectionChangeLogDTOList Count:{this.ActSectionChangeLogDTOList.Count}";
            status += $"AccusedChangeLogDTOList Count:{this.AccusedChangeLogDTOList?.Count}";
            return status;
        }
    }

    public class FirChangeLogDTOList
    {
        public int FIRCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
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
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ActSectionChangeLogDTOList
    {
        public int FIRSectionCode { get; set; }
        public int FIRCode { get; set; }
        public int ActSectionCode { get; set; }
        public string Section { get; set; }
        public string SectionTitle { get; set; }
        public string Act { get; set; }
        public string IsForMinor { get; set; }
        public DateTime AddedOn { get; set; }
        public string IsAddedLater { get; set; }
        public string Notes { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class AccusedChangeLogDTOList
    {
        public int FIRAccusedCode { get; set; }
        public int FIRCode { get; set; }
        public string TraffickerId { get; set; }
        public string TraffickerName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Alias { get; set; }
        public string IdentificationMark { get; set; }
        public int AccusedTypeCode { get; set; }
        public string AccusedType { get; set; }
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