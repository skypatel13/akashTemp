using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class SurvivorDocumentResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SurvivorDocumentDTO> survivorDocumentsList { get; set; }

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
            status += $"Survivor Document List:{this.survivorDocumentsList.Count}";
            return status;
        }
    }
    public class SurvivorDocumentDTO
    {
        public int DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public int DocumentReferenceCode { get; set; }
        public string DocumentReference { get; set; }
        public string IsRequiredForSurvivor { get; set; }
        public bool IsSurvivorSpecificValue { get; set; }
        public string IsSurvivorSpecificText { get; set; }
        public int SurvivorDocumentCode { get; set; }
        public int SurvivorCode { get; set; }
        public int ReferenceRecordCode { get; set; }
        public string FileName { get; set; }
        public string StoredAsFileName { get; set; }
        public string IsAvailable { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
