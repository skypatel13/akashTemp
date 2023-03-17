using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class FirAccusedDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<FirAssignedAccusedDTOList> assignedAccusedDTOLists { get; set; }

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
            status += $"Assigned AccusedDTOLists Count:{this.assignedAccusedDTOLists.Count}";
            return status;
        }
    }
    public class FirAssignedAccusedDTOList
    {
        public int FIRAccusedCode { get; set; }
        public int FIRCode { get; set; }
        public string TraffickerId { get; set; }
        public int AccusedTypeCode { get; set; }
        public string AccusedType { get; set; }
        public int TraffickerCode { get; set; }
        public string TraffickerName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public int GenderCode { get; set; }
        public int Age { get; set; }
        public string IdentificationMark { get; set; }
        public string IsDeleted { get; set; }
        public Boolean IsSelected { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}