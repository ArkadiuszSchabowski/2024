using api.Entities;
using api.Models;
using AutoMapper;

namespace api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDto, AppUser>();
            CreateMap<AppUser, RegisterUserDto>();
        }
    }
}
