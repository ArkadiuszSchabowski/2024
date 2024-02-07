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
        User? RemoveUser(int id);
        User? UpdateUser(int id, UpdateUserDto dto);
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

        public User? RemoveUser(int id)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Id == id);
            if(user != null)
            {
            _context.Users.Remove(user);
            _context.SaveChanges();
            }
            return user;
        }

        public User? UpdateUser(int id, UpdateUserDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if(user!= null)
            {
                var updatedUser = _mapper.Map(dto, user);
                _context.SaveChanges();
                return updatedUser;
            }
            return null;
        }
    }
}
