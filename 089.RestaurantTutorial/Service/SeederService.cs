using _089.RestaurantTutorial.Entities;

namespace _089.RestaurantTutorial.Service
{
    public class SeederService
    {
        private readonly MyDbContext _context;
        public SeederService(MyDbContext context)
        {
            _context = context;
        }
        public void SeedRoles()
        {
            if (!_context.Roles.Any())
            {
                _context.Roles.AddRange(new Role
                {
                    Name = "User"
                },
                new Role
                {
                    Name = "Manager"
                },
                new Role
                {
                    Name = "Admin"
                });
            }
        }
        public void SeedRestaurantAndAdress()
        {
            if (!_context.Restaurants.Any())
            {
                var restaurant1 = new Restaurant
                {
                    Name = "Hong Viet",
                    Description = "Restauracja Orientalna",
                    HasDelivery = true,
                    ContactPhone = "500-001-002",
                    AddressId = 1,
                    Address = new Address
                    {
                        RestaurantId = 1,
                        Street = "Wolności 6",
                        City = "Chorzów",
                        PostalCode = "41-500",
                    },
                    Dishes = new List<Dish>()

                };
                var restaurant2 = new Restaurant
                {
                    Name = "Wegeteriańska Świnka",
                    Description = "Dania wegetariańskie",
                    HasDelivery = true,
                    ContactPhone = "550-551-552",

                    AddressId = 2,
                    Address = new Address
                    {
                        RestaurantId = 2,
                        Street = "Kochanowskiego 69",
                        City = "Świętochłowice",
                        PostalCode = "41-506",
                    },
                    Dishes = new List<Dish>()
                };
                _context.Restaurants.AddRange(restaurant1, restaurant2);
                _context.SaveChanges();
            }
        }
    }
}

