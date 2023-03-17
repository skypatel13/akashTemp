using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class BlockDTOListResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<BlockDTOList> BlockDTOList { get; set; }
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
            status += $"BlockDTOList Count:{this.BlockDTOList.Count}";
            return status;
        }
    }
    public class BlockDTOList
    {
        public int BlockCode { get; set; }
        public int BlockMunicipalityCode { get; set; }
        public string BlockMunicipality { get; set; }
        public string Block { get; set; }
        public int DistrictCode { get; set; }
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