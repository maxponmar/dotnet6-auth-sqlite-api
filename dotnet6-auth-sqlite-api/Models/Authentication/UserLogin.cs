using System.ComponentModel.DataAnnotations;

namespace dotnet6_auth_sqlite_api.Models.Authentication
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
