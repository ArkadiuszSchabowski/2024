using Microsoft.AspNetCore.Identity;

namespace _089.RestaurantTutorial.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public int RoleId { get; set; } = 1;
        public Role Role { get; set; }
    }
}
