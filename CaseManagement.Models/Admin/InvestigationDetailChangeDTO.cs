using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    //public class InvestigationDetailChangeDTOResponse
    //{
    //    public DataUpdateResponseDTO DataUpdateResponse { get; set; }
    //    public List<InvestigationDetailChangeDTOList> InvestigationDetailChangeDTOList { get; set; }
    //    public override string ToString()
    //    {
    //        if (this.DataUpdateResponse == null)
    //        {
    //            return $"No status available";
    //        }
    //        string status = DataUpdateResponse.ToString();
    //        if (!DataUpdateResponse.Status)
    //        {
    //            return status;
    //        }
    //        status += $"InvestigationDetailChangeDTOList Count:{InvestigationDetailChangeDTOList.Count}";
    //        return status;
    //    }
    //}
    //public class InvestigationDetailChangeDTOList
    //{
    //    public int InvestigationCode { get; set; }
    //    public int InvestigationAgencyLogCode { get; set; }
    //    public int InvestingAgencyCode { get; set; }
    //    public string InvestingAgency { get; set; }
    //    public int InvestingAgencyTypeCode { get; set; }
    //    public string InvestingAgencyType { get; set; }
    //    public string InvestigatingOfficer { get; set; }
    //    public int OfficerRankCode { get; set; }
    //    public string OfficerRank { get; set; }
    //    public DateTime? ChangeDate { get; set; }
    //    public string Reason { get; set; }
    //    public int ReasonCode { get; set; }
    //    public string IsDeleted { get; set; }
    //    public DateTime? ValidFrom { get; set; }
    //    public DateTime? ValidTo { get; set; }
    //    public int ChangeTypeCode { get; set; }
    //    public string ChangeType { get; set; }
    //    public override string ToString()
    //    {
    //        return JsonConvert.SerializeObject(this);
    //    }
    //}
}
