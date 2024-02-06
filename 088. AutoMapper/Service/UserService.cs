using _088._AutoMapper.Models;
using AutoMapper;
using AutoMapper.Database;
using AutoMapper.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _088._AutoMapper.Service
{
    public interface IUserService
    {
        User CreateUser(CreateUserDto userDto);
        User? GetUser(int id);
        IEnumerable<User> GetUsers();
        UserDto MapUserToDto(User user);
    }

    public class UserService : IUserService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public UserService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public User CreateUser(CreateUserDto userDto)
        {
            CreateUserDto? user = new CreateUserDto()
            {
                Name = userDto.Name,
                City = userDto.City,
                Phone = userDto.Phone,
            };

            User newUser = _mapper.Map<User>(user);

            newUser.isPremiumAccount = false;
            newUser.isAdmin = false;

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public User? GetUser(int id)
        {
            User? user = _context.Users.Find(id);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();

        }

        public UserDto MapUserToDto(User user)
        {
            UserDto userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
