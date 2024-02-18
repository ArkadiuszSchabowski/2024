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

            CreateMap<RestaurantDto, Restaurant>()
                .ForMember(r => r.Address, d => d.MapFrom(dto => new Address
                {
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode
                }));

            CreateMap<CreateDishDto, Dish>();
        }
    }
}
