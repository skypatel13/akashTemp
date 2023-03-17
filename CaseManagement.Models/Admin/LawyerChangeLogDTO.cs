using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class LawyerChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LawyerChangeLogDTOList> LawyerChangeLogDTOList { get; set; }
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
            status += $"LawyerChangeLogDTOList Count:{this.LawyerChangeLogDTOList.Count}";
            return status;
        }
    }
    public class LawyerChangeLogDTOList
    {
        public int SurvivorLawyerCode { get; set; }
        public int SurvivorCode { get; set; }
        public int MemberLawyerTypeCode { get; set; }
        public int MemberCode { get; set; }
        public string MemberName { get; set; }
        public int LawyerTypeCode { get; set; }
        public string LawyerType { get; set; }
        public int SourceDestinationCode { get; set; }
        public string SourceDestination { get; set; }
        public string LeadingFor { get; set; }
        public string IsLeadingText { get; set; }
        public bool IsLeadingValue { get; set; }
        public DateTime? LeadingFrom { get; set; }
        public DateTime? LeadingTo { get; set; }
        public string Notes { get; set; }
        public string SurvivorName { get; set; }
        public string AliasNames { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string PoliceStationName { get; set; }
        public int OrganizationId { get; set; }
        public string Organization { get; set; }
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
