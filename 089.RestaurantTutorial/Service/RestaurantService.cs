﻿using _089.RestaurantTutorial.Entities;
using _089.RestaurantTutorial.Exceptions;
using _089.RestaurantTutorial.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _089.RestaurantTutorial.Service
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetAll();
        RestaurantDto GetRestaurant(int id);
    }

    public class RestaurantService : IRestaurantService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public RestaurantService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants
                .Include(r => r.Dishes)
                .Include(r => r.Address)
                .ToList();
        }

        public RestaurantDto GetRestaurant(int id)
        {
            var restaurant = _context.Restaurants
                .Include(r => r.Dishes)
                .Include(r => r.Address)
                .FirstOrDefault(r => r.Id == id);

            if (restaurant == null)
            {
                throw new NotFoundException("Nie znaleziono restauracji o podanym Id!");
            }

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return restaurantDto;
        }
    }
}
