using _089.RestaurantTutorial.Entities;

namespace _089.RestaurantTutorial.Service
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class RestaurantService : IRestaurantService
    {
        private readonly MyDbContext _context;
        public RestaurantService(MyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }
    }
}
