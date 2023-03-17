using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.AuthData
{
    public class UpdatePasswordDTODB
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Current Password is required")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
