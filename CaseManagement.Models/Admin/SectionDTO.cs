using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class SectionDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<SectionDTOList> ActSectionDTOList { get; set; }

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
            status += $"ActSectionDTOList Count:{this.ActSectionDTOList.Count}";
            return status;
        }
    }
    public class SectionDTOList
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

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}