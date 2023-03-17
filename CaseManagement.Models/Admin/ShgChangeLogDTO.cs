using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class ShgChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<ShgChangeLogDTOList> ShgChangeLogDTOList { get; set; }

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
            status += $"ShgChangeLogDTO List:{this.ShgChangeLogDTOList.Count}";
            return status;
        }
    }

    public class ShgChangeLogDTOList
    {
        public int ShgCode { get; set; }
        public int OrganizationId { get; set; }
        public string IsDeleted { get; set; }
        public string RecordMode { get; set; }
        public string ShgId { get; set; }
        public string ShgName { get; set; }
        public string Organization { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}