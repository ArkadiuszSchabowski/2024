using _089.RestaurantTutorial.Entities;
using _089.RestaurantTutorial.Models;
using AutoMapper;

namespace _089.RestaurantTutorial
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(d => d.City, r => r.MapFrom(r => r.Address.City))
                .ForMember(d => d.Street, r => r.MapFrom(r => r.Address.Street))
                .ForMember(d => d.PostalCode, r => r.MapFrom(r => r.Address.PostalCode));

            CreateMap<Dish, DishDto>();
        }
    }
}
