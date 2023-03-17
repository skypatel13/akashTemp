using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class BlockDTOEditDB
    {
        public int BlockCode { get; set; }
        public int BlockMunicipalityCode { get; set; }
        public string Block { get; set; }
        public int DistrictCode { get; set; }
        public int StateCode { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
