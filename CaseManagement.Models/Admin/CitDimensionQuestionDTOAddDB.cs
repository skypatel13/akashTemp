using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class CitDimensionQuestionDTOAddDB
    {
        public int VersionDimensionCode { get; set; }
        public string QuestionData { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}