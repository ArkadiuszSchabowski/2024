using System.ComponentModel.DataAnnotations;

namespace _088._AutoMapper.Models
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
    }
}
