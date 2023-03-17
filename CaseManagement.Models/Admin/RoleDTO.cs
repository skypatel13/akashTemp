using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class RoleDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<RoleDTOList> RoleDTOList { get; set; }

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
            status += $"RoleDTOList Count:{this.RoleDTOList.Count}";
            return status;
        }
    }

    public class RoleDTOList
    {
        public string Role { get; set; }
        public string RoleId { get; set; }
        public string Purpose { get; set; }
        public string Notes { get; set; }
        public string IsDeleted { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}