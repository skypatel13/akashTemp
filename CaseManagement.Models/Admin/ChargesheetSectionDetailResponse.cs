using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class ChargesheetSectionDetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<ChargesheetActSectionDTOList> ChargesheetActSectionDTOList { get; set; }
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
            status += $"ChargesheetActSectionDTOList Count:{ChargesheetActSectionDTOList.Count}";
            return status;
        }
    }
    public class ChargesheetActSectionDTOList
    {
        public int ActCode { get; set; }
        public string Act { get; set; }
        public string ActName { get; set; }
        public int ActSectionCode { get; set; }
        public string Section { get; set; }
        public string SectionTitle { get; set; }
        public string IsForMinor { get; set; }
        public int ChargesheetCode { get; set; }
        public string IsAddedLater { get; set; }
        public DateTime AddedOn { get; set; }
        public bool IsFIRSection { get; set; }
        public string IsFIRSectionText { get; set; }
        public bool IsSelected { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
