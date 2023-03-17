using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class PCWhyDataListDTO
    {
        public int PCCode { get; set; }
        public int WhyPCCode { get; set; }
        public string WhyPC { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}