using AutoMapper.Database;
using AutoMapper.Database.Entities;

namespace _088._AutoMapper.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
    }

    public class UserService : IUserService
    {
        private readonly MyDbContext _context;
        public UserService(MyDbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();

        }
    }
}
