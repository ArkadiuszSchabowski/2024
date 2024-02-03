using _089.RestaurantTutorial.Entities;

namespace _089.RestaurantTutorial.Models
{

    public class RestaurantDto
    {
        public readonly Restaurant _restaurant;

        public RestaurantDto()
        {
        }

        public RestaurantDto(Restaurant restaurant)
        {
            _restaurant = restaurant;
            Id = restaurant.Id;
            Name = restaurant.Name;
            Description = restaurant.Description;
            HasDelivery = restaurant.HasDelivery;
            Street = restaurant.Address.Street;
            City = restaurant.Address.City;
            PostalCode = restaurant.Address.PostalCode;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasDelivery { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public List<DishDto> Dishes { get; set; }
    }
}
