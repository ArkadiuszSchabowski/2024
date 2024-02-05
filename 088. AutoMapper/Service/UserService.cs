using AutoMapper.Database;
using AutoMapper.Database.Entities;

namespace _088._AutoMapper.Service
{
    public interface IUserService
    {
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
