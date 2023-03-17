using CaseManagement.Models.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CaseManagement.Models.Admin
{
    public class DocumentTypeChangeLogDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }
        public List<DocumentTypeChangeLogDTOList> DocumentTypeChangeLogDTOList { get; set; }
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
            status += $"DocumentTypeChangeLogDTO List:{this.DocumentTypeChangeLogDTOList.Count}";
            return status;
        }
    }
    public class DocumentTypeChangeLogDTOList
{
        public int DocumentCode { get; set; }
        public string DocumentName { get; set; }
        public string IsRequiredForSurvivor { get; set; }
        public string IsSurvivorSpecific { get; set; }
        public string Notes { get; set; }
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
