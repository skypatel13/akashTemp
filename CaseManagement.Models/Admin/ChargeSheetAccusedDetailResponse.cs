using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class ChargeSheetAccusedDetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<ChargeSheetAccusedDTOList> ChargeSheetAccusedDTOList { get; set; }
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
            status += $"ChargeSheetAccusedDTOList Count:{ChargeSheetAccusedDTOList.Count}";
            return status;
        }
    }
    public class ChargeSheetAccusedDTOList
    {
        public int ChargesheetAccusedCode { get; set; }
        public int FirAccusedCode { get; set; }
        public int ChargesheetCode { get; set; }
        public string TraffickerId { get; set; }
        public int TraffickerCode { get; set; }
        public string TraffickerName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public int GenderCode { get; set; }
        public string IdentificationMark { get; set; }
        public int Age { get; set; }
        public string IsDeleted { get; set; }
        public bool IsFIRAccused { get; set; }
        public string IsFIRAccusedText { get; set; }
        public bool IsSelected { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
