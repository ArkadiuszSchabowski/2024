using _088._AutoMapper.Models;
using AutoMapper;
using AutoMapper.Database;
using AutoMapper.Database.Entities;

namespace _088._AutoMapper.Service
{
    public interface IUserService
    {
        UserDto? CreateUser(UserDto userDto);
        User? GetUser(int id);
        IEnumerable<User> GetUsers();
    }

    public class UserService : IUserService
    {
        private readonly MyDbContext _context;
        public UserService(MyDbContext context)
        {
            _context = context;
        }

        public UserDto? CreateUser(UserDto userDto)
        {
            var user = new UserDto
            {
                Name = userDto.Name,
                City = userDto.City,
                Phone = userDto.Phone
            };
            return user;
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
    }
}
