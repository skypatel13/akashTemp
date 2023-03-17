using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class LookupPoliceStationWithLocationDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LookupStateDTOList> LookupStateDTOList { get; set; }
        public List<LookupStateDistrictDTOList> LookupStateDistrictDTOList { get; set; }
        public List<LookupBlockDTOList> LookupBlockDTOList { get; set; }
        public List<LookupPoliceStationDTOList> LookupPoliceStationDTOList { get; set; }
        public List<LookupVillageDTOList> LookupVillageDTOList { get; set; }
        public List<LookupPanchayatDTOList> LookupPanchayatDTOList { get; set; }
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
            status += $"StateDTO List Count:{this.LookupStateDTOList.Count}";
            status += $"District List Count:{this.LookupStateDistrictDTOList.Count}";
            status += $"Block List Count:{this.LookupBlockDTOList.Count}";
            status += $"PoliceStation List Count:{this.LookupPoliceStationDTOList.Count}";
            status += $"Village List Count:{this.LookupVillageDTOList.Count}";
            status += $"Panchayat List Count:{this.LookupPanchayatDTOList.Count}";
            return status;
        }
    }

    public class LookupPoliceStationDTOList
    {
        public int StateCode { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int BlockCode { get; set; }
        public string Block { get; set; }
        public int PoliceStationCode { get; set; }
        public string PoliceStationName { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class LookupVillageDTOList
    {
        public int VillageCode { get; set; }
        public string Village { get; set; }
        public int StateCode { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int BlockCode { get; set; }
        public string Block { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class LookupPanchayatDTOList
    {
        public int PanchayatCode { get; set; }
        public string Panchayat { get; set; }
        public int StateCode { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int BlockCode { get; set; }
        public string Block { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}