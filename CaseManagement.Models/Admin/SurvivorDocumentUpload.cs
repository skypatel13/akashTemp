using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class SurvivorDocumentUpload
    {
        public int SurvivorCode { get; set; }
        public int DocumentCode { get; set; }
        public IFormFile FileName { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
