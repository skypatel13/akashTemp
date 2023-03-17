using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class ShelterHomeContactDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<ShelterHomeContactDTOList> ShelterHomeContactDTOList { get; set; }

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
            status += $"ShelterHomeContactDTOList Count:{ShelterHomeContactDTOList.Count}";
            return status;
        }
    }

    public class ShelterHomeContactDTOList
    {
        public int ShelterHomeContactCode { get; set; }
        public int ShelterHomeCode { get; set; }
        public string ShelterHomeName { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}