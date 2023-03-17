using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class LegalServiceTypeChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<LegalServiceTypeChangeLogDTOList> LegalServiceTypeChangeLogDTOList { get; set; }
        public List<LegalServiceTypeChangeLogProgramAxis> legalServiceTypeChangeLogProgramAxes { get; set; }

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
            status += $"Legal ServiceType ChangeLog List Count:{this.LegalServiceTypeChangeLogDTOList.Count}";
            status += $"Legal ServiceType ChangeLog ProgramAxis List Count:{this.legalServiceTypeChangeLogProgramAxes.Count}";
            return status;
        }
    }

    public class LegalServiceTypeChangeLogDTOList
    {
        public int LegalServiceTypeCode { get; set; }
        public string LegalServiceTypeId { get; set; }
        public string LegalServiceTypeName { get; set; }
        public int AuthorityLevelCode { get; set; }
        public string AuthorityLevel { get; set; }
        public int IsCourtValue { get; set; }
        public string IsCourtText { get; set; }
        public string IsDeleted { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string RecordMode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class LegalServiceTypeChangeLogProgramAxis
    {
        public int LegalServiceTypeMapCode { get; set; }
        public string LegalServiceTypeId { get; set; }
        public int ProgramAxisCode { get; set; }
        public string ProgramAxis { get; set; }
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