using api.Entities;

namespace api.Services
{
    public interface IUserService
    {
        List<AppUser> GetAll();
        AppUser GetUser(int id);
    }
    public class UserService : IUserService
    {
        private readonly MyDbContext _context;

        public UserService(MyDbContext context)
        {
            _context = context;
        }
        public List<AppUser> GetAll()
        {
            return _context.Users.ToList();
        }
        public AppUser GetUser(int id)
        {
            AppUser user = _context.Users.Find(id);
            return user;
        }
    }

}
