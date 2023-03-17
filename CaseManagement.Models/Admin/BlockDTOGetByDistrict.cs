using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace CaseManagement.Models.Admin
{
    public class BlockDTOListGetByDistrictResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<BlockDTOListGetByDistrict> BlockDTOListGetByDistrict { get; set; }
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
            status += $"BlockDTOListGetByDistrict Count:{this.BlockDTOListGetByDistrict.Count}";
            return status;
        }
    }
    public class BlockDTOListGetByDistrict
    {
        public int BlockCode { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public string IsDeleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}
