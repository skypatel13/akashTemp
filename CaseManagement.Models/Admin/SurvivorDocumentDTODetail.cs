using Newtonsoft.Json;
using System;

namespace CaseManagement.Models.Admin
{
    public class SurvivorDocumentDTODetail
    {
        public int SurvivorDocumentCode { get; set; }
        public int SurvivorCode { get; set; }
        public int DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public int ReferenceRecordCode { get; set; }
        public string FileName { get; set; }
        public string StoredAsFileName { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedOn { get; set; }
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
