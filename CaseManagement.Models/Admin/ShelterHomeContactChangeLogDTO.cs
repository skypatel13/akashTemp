using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class ShelterHomeContactChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<ShelterHomeContactChangeLogDTOList> ShelterHomeContactChangeLogDTOList { get; set; }

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
            status += $"ShelterHomeContactChangeLogDTOList Count:{ShelterHomeContactChangeLogDTOList.Count}";
            return status;
        }
    }

    public class ShelterHomeContactChangeLogDTOList
    {
        public int ShelterHomeContactCode { get; set; }
        public int ShelterHomeCode { get; set; }
        public string ShelterHomeName { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
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