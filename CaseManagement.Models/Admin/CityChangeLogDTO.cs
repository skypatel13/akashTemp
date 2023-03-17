using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class CityChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<CityChangeLogDTO> cityChangeLogDTOs { get; set; }

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
            status += $"CityChangeLogDTO List:{this.cityChangeLogDTOs.Count}";
            return status;
        }
    }

    public class CityChangeLogDTO
    {
        public int CityCode { get; set; }
        public string City { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int StateCode { get; set; }
        public string State { get; set; }
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