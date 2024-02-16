using System.Text.Json.Serialization;

namespace _089.RestaurantTutorial.Models
{
    public class DishDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
