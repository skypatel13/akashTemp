using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class ActChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<ActChangeLogDTOList> ActChangeLogDTOList { get; set; }

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
            status += $"ActChangeLogDTO Count:{this.ActChangeLogDTOList.Count}";
            return status;
        }
    }

    public class ActChangeLogDTOList
    {
        public int ActCode { get; set; }
        public string Act { get; set; }
        public string ActName { get; set; }
        public DateTime? EnforcementDate { get; set; }
        public DateTime? GazetteDate { get; set; }
        public string GazetteFile { get; set; }
        public string RefURL { get; set; }
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