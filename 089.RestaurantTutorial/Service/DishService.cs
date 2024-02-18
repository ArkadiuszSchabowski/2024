using _089.RestaurantTutorial.Entities;
using _089.RestaurantTutorial.Exceptions;
using _089.RestaurantTutorial.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace _089.RestaurantTutorial.Service
{
    public interface IDishService
    {
        void CreateDish(int restaurantId, CreateDishDto dishDto);
        List<Dish> GetAllDishes(int restaurantId);
        Dish GetDish(int restaurantId, int dishId);
    }
    public class DishService : IDishService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public DishService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void CreateDish(int restaurantId, CreateDishDto createDishDto)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == restaurantId);

            if(restaurant == null)
            {
                throw new NotFoundException("Nie znaleziono restauracji o podanym Id!");
            }

            Dish dish = _mapper.Map<Dish>(createDishDto);
            dish.RestaurantId = restaurantId;
            _context.Dishes.Add(dish);
            _context.SaveChanges();
        }

        public List<Dish> GetAllDishes(int restaurantId)
        {
            var restaurant = _context.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefault(r => r.Id == restaurantId);

            if (restaurant == null)
            {
                throw new NotFoundException("Nie znaleziono restauracji o podanym Id!");
            }
            return restaurant.Dishes;
        }

        public Dish GetDish(int restaurantId, int dishId)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == restaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException("Nie znaleziono restauracji o podanym Id!");
            }
            var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == dishId);
            if(dish == null)
            {
                    throw new NotFoundException("Nie znaleziono dania o podanej nazwie!");
            }
            return dish;
        }
    }

}
