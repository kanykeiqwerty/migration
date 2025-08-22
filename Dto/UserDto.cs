using System.ComponentModel.DataAnnotations;

namespace MigrationApi.Dto
{
    public class RegisterUserDto
    {
        public string UserName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleID { get; set; }


    }

    public class LoginDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }


    public class NewUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string? RoleName { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}