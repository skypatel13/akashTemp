using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class FirActSectionDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<FirAssignedActSectionDTOList> firAssignedActSectionDTOLists { get; set; }

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
            status += $"Assigned AccusedDTOLists Count:{this.firAssignedActSectionDTOLists.Count}";
            return status;
        }
    }
    public class FirAssignedActSectionDTOList
    {
        public int ActCode { get; set; }
        public string Act { get; set; }
        public string ActName { get; set; }
        public int ActSectionCode { get; set; }
        public string Section { get; set; }
        public string SectionTitle { get; set; }
        public string IsForMinor { get; set; }
        public Boolean IsSelected { get; set; }
        public int FIRCode { get; set; }
        public string IsAddedLater { get; set; }
        public DateTime? AddedOn { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}