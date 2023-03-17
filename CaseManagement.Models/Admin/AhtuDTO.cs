using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class AhtuDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<AhtuDTOList> AhtuDTOList { get; set; }
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
            status += $"AhtuDTOList Count:{AhtuDTOList.Count}";
            return status;
        }
    }
    public class AhtuDTOList
    {
        public int AHTUCode { get; set; }
        public string AHTUName { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int StateCode { get; set; }
        public string State { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}