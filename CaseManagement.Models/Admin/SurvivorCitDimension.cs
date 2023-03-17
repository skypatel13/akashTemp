using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorCitDimension
    {
        public int SurAsmtDimCode { get; set; }
        public int SurAsmtCode { get; set; }
        public int VersionDimensionCode { get; set; }
        public int DimensionCode { get; set; }
        public string DimensionName { get; set; }
        public int? Score { get; set; } 
        public bool IsSelected { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreadtedBy { get; set; }
        public string CreadtedByIpAddress { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
