using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class ChargeSheetDTODetail
    {
        public int ChargeSheetCode { get; set; }
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public int InvestigationCode { get; set; }
        public string ChargeSheetNumber { get; set; }
        public DateTime ChargeSheetDate { get; set; }
        public string TypeOfViolation { get; set; }
        public string ChargeSheetCopy { get; set; }
        public string ChargeSheetCopyStoredAs { get; set; }
        public string InvestingAgencyType { get; set; }
        public string InvestingAgency { get; set; }
        public string InvestigatingOfficer { get; set; }
        public string OfficerRank { get; set; }
        public string SourceDestination { get; set; }
        public string Sections { get; set; }
        public string Traffickers { get; set; }
        public List<ChargeSheetSectionDTOList> ChargeSheetSectionDTOList { get; set; }
        public List<ChargeSheetAccuseDTOList> ChargeSheetAccuseDTOList { get; set; }
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
