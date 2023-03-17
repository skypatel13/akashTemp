using Newtonsoft.Json;

namespace CaseManagement.Models.Admin
{
    public class ShelterHomeContactDTOEdit
    {
        public int ShelterHomeContactCode { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}