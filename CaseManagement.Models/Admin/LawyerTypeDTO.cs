using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class LawyerTypeDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LawyerTypeDTOList> LawyerTypeDTOList { get; set; }

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
            status += $"LawyerTypeDTOList Count:{this.LawyerTypeDTOList.Count}";
            return status;
        }
    }

    public class LawyerTypeDTOList
    {
        public int LawyerTypeCode { get; set; }
        public string LawyerType { get; set; }
        public string Notes { get; set; }
        public string IsDeleted { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}