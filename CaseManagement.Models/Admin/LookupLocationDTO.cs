using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseManagement.Models.Admin
{
    public class LookupLocationDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LookupStateDTOList> lookupStateDTOLists { get; set; }
        public List<LookupStateDistrictDTOList> lookupStatesDistricts { get; set; }
        public List<LookupBlockDTOList> lookupBlockDTOLists { get; set; }

        public override string ToString()
        {
            if (this.DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (!this.DataUpdateResponse.Status)
            {
                return status;
            }
            status += $"StateDTO List Count:{this.lookupStateDTOLists.Count}";
            status += $"District List Count:{this.lookupStatesDistricts.Count}";
            status += $"Block List Count:{this.lookupBlockDTOLists.Count}";
            return status;
        }

    }
    public class LookupStateDTOList
    {
        public string StateId { get; set; }
        public string State { get; set; }
        public int StateCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class LookupBlockDTOList
    {
        public int BlockCode { get; set; }
        public string Block { get; set; }
        public int BlockMunicipalityCode { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int StateCode { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
