using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class ShelterHomeContactDTOEditDB
    {
        public int ShelterHomeContactCode { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}