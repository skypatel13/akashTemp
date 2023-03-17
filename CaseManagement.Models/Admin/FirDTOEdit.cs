using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class FirDTOEdit
    {
        public int FIRCode { get; set; }
        public int SourceDestinationCode { get; set; }
        public string DeFactoComplainer { get; set; }
        public int NumberOfAccused { get; set; }
        public int RelationCode { get; set; }
        public string GDNumber { get; set; }
        public DateTime? GDDate { get; set; }
        public string GDIssue { get; set; }
        public string FIRNumber { get; set; }
        public string FIRIssue { get; set; }
        public DateTime FIRDate { get; set; }
        public string FIRCopyStoredAs { get; set; }
        public Boolean IsFIRCopyChanged { get; set; }
        public IFormFile FIRCopy { get; set; }
        public string GDCopyStoredAs { get; set; }
        public IFormFile GDCopy { get; set; }
        public Boolean IsGDCopyChanged { get; set; }
        public string FirActSectionMappingDTOLists { get; set; }
        public string FirAccusedMappingDTOList { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}