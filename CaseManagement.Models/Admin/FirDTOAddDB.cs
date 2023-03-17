using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class FirDTOAddDB
    {
        public int SurvivorCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public string DeFactoComplainer { get; set; }
        public int NumberOfAccused { get; set; }
        public int RelationCode { get; set; }
        public string GDNumber { get; set; }
        public DateTime? GDDate { get; set; }
        public string GDIssue { get; set; }
        public string FIRNumber { get; set; }
        public DateTime FIRDate { get; set; }
        public string FIRIssue { get; set; }
        public string FIRCopy { get; set; }
        public string GDCopy { get; set; }
        public string ActSectionData { get; set; }
        public string TraffickerData { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}