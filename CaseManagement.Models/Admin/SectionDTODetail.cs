using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SectionDTODetailResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public SectionDTODetail ActSectionDTODetail { get; set; }

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
            status += $"ActSectionDTODetail :{this.ActSectionDTODetail}";
            return status;
        }
    }

    public class SectionDTODetail
    {
        public int ActSectionCode { get; set; }
        public string Section { get; set; }
        public string Title { get; set; }
        public int ActCode { get; set; }
        public string Act { get; set; }
        public string Notes { get; set; }
        public string IsForMinorText { get; set; }
        public bool IsForMinorValue { get; set; }
        public string RefURL { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public string IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}