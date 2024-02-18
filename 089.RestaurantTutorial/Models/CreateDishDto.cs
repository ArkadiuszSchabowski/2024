using System.ComponentModel.DataAnnotations;

namespace _089.RestaurantTutorial.Models
{
    public class CreateDishDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int RestaurantId { get; set; }
    }
}
