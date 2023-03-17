using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class VillageChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<VillageChangeLogDTOList> VillageChangeLogDTOList { get; set; }
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
            status += $"VillageChangeLogDTOList Count:{VillageChangeLogDTOList.Count}";
            return status;
        }
    }
    public class VillageChangeLogDTOList
    {
        public int VillageCode { get; set; }
        public string Village { get; set; }
        public int BlockCode { get; set; }
        public string Block { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int StateCode { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public bool IsWardValue { get; set; }
        public string IsWardText { get; set; }
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
