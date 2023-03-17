using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.AuthData
{
    /// <summary>
    /// To get login credential from the user
    /// </summary>
    public class LoginModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}