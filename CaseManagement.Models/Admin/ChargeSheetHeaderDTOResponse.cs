using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class ChargeSheetHeaderDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public ChargeSheetHeaderDTO ChargeSheetHeaderDTO { get; set; }
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
            status += $"ChargeSheetHeaderDTO :{ChargeSheetHeaderDTO}";
            return status;
        }
    }
    public class ChargeSheetHeaderDTO 
    {
        public int SurvivorCode { get; set; }
        public int FirCode { get; set; }
        public string FirNumber { get; set; }
        public Nullable<DateTime> FirDate { get; set; }
        public string SourceDestination { get; set; }
        public string InvestingAgencyType { get; set; }
        public string InvestingAgency { get; set; }
        public string InvestigatingOfficer { get; set; }
        public string OfficerRank { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
