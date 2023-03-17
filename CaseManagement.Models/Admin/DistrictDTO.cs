using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DistrictDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DistrictDTOList> DistrictDTOList { get; set; }
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
            status += $"DistrictDTO List:{this.DistrictDTOList.Count}";
            return status;
        }
    }
    public class DistrictDTOList
    {
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int StateCode { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
