using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorDocumentUploadDB
    {
        public int SurvivorCode { get; set; }
        public DocumentTypes DocumentCode { get; set; }
        public string FileName { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
