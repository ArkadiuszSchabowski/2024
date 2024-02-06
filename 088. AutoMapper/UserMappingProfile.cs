using _088._AutoMapper.Models;
using AutoMapper;
using AutoMapper.Database.Entities;

namespace _088._AutoMapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();
        }
    }
}
