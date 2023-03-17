using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class MemberLawyerDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<MemberLawyerDTOList> MemberLawyerDTOList { get; set; }
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
            status += $"MemberLawyerDTOList Count:{MemberLawyerDTOList.Count}";
            return status;
        }
    }
    public class MemberLawyerDTOList
    {
        public int MemberCode { get; set; }
        public string MemberName { get; set; }
        public int MemberLawyerTypeCode { get; set; }
        public string Category { get; set; }
        public string Organization { get; set; }
        public int LawyerTypeCode { get; set; }
        public string LawyerType { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}