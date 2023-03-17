using CaseManagement.Models.Admin;
using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models
{
    public class ChargeSheetChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<ChargeSheetChangeLogDTOList> ChargeSheetChangeLogDTOList { get; set; }
        public List<ChargeSheetActSectionChangeLogDTOList> ChargeSheetActSectionChangeLogDTOList { get; set; }
        public List<ChargeSheetAccusedChangeLogDTOList> ChargeSheetAccusedChangeLogDTOList { get; set; }

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
            status += $"ChargeSheetChangeLogDTOList Count:{this.ChargeSheetChangeLogDTOList.Count}";
            status += $"ChargeSheetActSectionChangeLogDTOList Count:{this.ChargeSheetActSectionChangeLogDTOList.Count}";
            status += $"ChargeSheetAccusedChangeLogDTOList Count:{this.ChargeSheetAccusedChangeLogDTOList?.Count}";
            return status;
        }
    }

    public class ChargeSheetChangeLogDTOList
    {
        public int SurvivorCode { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
        public int ChargeSheetCode { get; set; }
        public int InvestigationCode { get; set; }
        public string ChargeSheetNumber { get; set; }
        public DateTime ChargeSheetDate { get; set; }
        public string TypeOfViolation { get; set; }
        public string Sections { get; set; }
        public string Traffickers { get; set; }
        public string IsDeleted { get; set; }
        public string Notes { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ChargeSheetActSectionChangeLogDTOList
    {
        public int ChargesheetSectionCode { get; set; }
        public int ChargesheetCode { get; set; }
        public int ActSectionCode { get; set; }
        public string Section { get; set; }
        public string SectionTitle { get; set; }
        public string Act { get; set; }
        public string IsForMinor { get; set; }
        public string SupplementaryNumber { get; set; }
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


    public class ChargeSheetAccusedChangeLogDTOList
    {
        public int ChargesheetAccusedCode { get; set; }
        public int ChargesheetCode { get; set; }
        public string TraffickerId { get; set; }
        public string TraffickerName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Alias { get; set; }
        public string IdentificationMark { get; set; }
        public string SupplementaryNumber { get; set; }
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
}
