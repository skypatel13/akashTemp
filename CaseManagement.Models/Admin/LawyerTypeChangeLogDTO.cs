using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace CaseManagement.Models.Admin
{
    public class LawyerTypeChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LawyerTypeChangeLogDTOList> LawyerTypeChangeLogDTOList { get; set; }
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
            status += $"LawyerTypeChangeLogDTO Count:{this.LawyerTypeChangeLogDTOList.Count}";
            return status;
        }
    }
    public class LawyerTypeChangeLogDTOList
    {
        public int LawyerTypeCode { get; set; }
        public string LawyerType { get; set; }
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
