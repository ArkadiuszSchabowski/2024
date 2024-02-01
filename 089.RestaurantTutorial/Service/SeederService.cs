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
        public void SeedRestaurantAndAdress()
        {
            if (!_context.Restaurants.Any())
            {
                var restaurant1 = new Restaurant
                {
                    Name = "Hong Viet",
                    Description = "Restauracja Orientalna",
                    HasDelivery = true,
                    ContantPhone = "500-001-002",
                    AddressId = 1,
                    Address = new Address
                    {
                        RestaurantId = 1,
                        Street = "Wolności 6",
                        City = "Chorzów",
                        Name = "ToDelete",
                        PostalCode = "41-500",
                    },
                    Dishes = new List<Dish>()

                };
                var restaurant2 = new Restaurant
                {
                    Name = "Wegeteriańska Świnka",
                    Description = "Dania wegetariańskie",
                    HasDelivery = true,
                    ContantPhone = "550-551-552",

                    AddressId = 2,
                    Address = new Address
                    {
                        RestaurantId = 2,
                        Street = "Kochanowskiego 69",
                        City = "Świętochłowice",
                        Name = "ToDelete",
                        PostalCode = "41-506",
                    },
                    Dishes = new List<Dish>()
                };
                _context.Restaurants.AddRange(restaurant1, restaurant2);
                _context.SaveChanges();
            }
        }
        public void AddDishesToWegetarianskaSwinka()
        {
            var dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Sałatka warzywna pomidor-burak",
                    Description = "Pyszna i pożywna sałatka",
                    RestaurantId = 2,
                    Price = "10.49",
                },
                                new Dish
                {
                    Name = "Sałatka owocowa jabłko-banan",
                    Description = "Sałatka poranna",
                    RestaurantId = 2,
                    Price = "7.99",
                },
            };
            _context.Dishes.AddRange(dishes);
            _context.SaveChanges();
        }

        public void DeleteWrongRecords()
        {
            var restaurant = _context.Restaurants.Where(r =>r.Id == 7 || r.Id == 8);
            if(restaurant != null)
            {
                _context.Restaurants.RemoveRange(restaurant);
                _context.SaveChanges();
            }

        }
    }
}

