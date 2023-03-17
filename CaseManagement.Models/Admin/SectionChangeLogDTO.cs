using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SectionLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SectionLogDTOList> ActSectionLogDTOList { get; set; }

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
            status += $"ActSectionLogDTOList Count:{this.ActSectionLogDTOList.Count}";
            return status;
        }
    }

    public class SectionLogDTOList
    {
        public int ActSectionCode { get; set; }
        public string Section { get; set; }
        public string Title { get; set; }
        public int ActCode { get; set; }
        public string Act { get; set; }
        public string Notes { get; set; }
        public string IsForMinor { get; set; }
        public string RefURL { get; set; }
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