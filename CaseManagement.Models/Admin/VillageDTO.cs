using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class VillageDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<VillageDTOList> VillageDTOList { get; set; }
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
            status += $"VillageDTOList Count:{VillageDTOList.Count}";
            return status;
        }
    }
    public class VillageDTOList
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
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
