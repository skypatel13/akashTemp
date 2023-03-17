using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.AuthData
{
    public class AppUser
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string UserPassword { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
