using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class LookupDTOListResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LookupDTOList> LookupDTOList { get; set; }

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
            status += $"LookupDTOList Count:{this.LookupDTOList.Count}";
            return status;
        }
    }

    public class LookupDTOList
    {
        public int Code { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}