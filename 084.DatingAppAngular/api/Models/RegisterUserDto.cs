using api.Entities;

namespace api.Models
{
    public class RegisterUserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
