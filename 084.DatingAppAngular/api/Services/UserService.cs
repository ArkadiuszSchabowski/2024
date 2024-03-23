using api.Entities;
using api.Exceptions;
using api.Models;
using AutoMapper;

namespace api.Services
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetUser(int id);
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
        public List<UserDto> GetAll()
        {
            var users = _context.Users.ToList();
            if(users == null)
            {
                throw new NotFoundException("Lista użytkowników jest pusta");
            }
            var usersDto = _mapper.Map<List<UserDto>>(users);

            return usersDto;
        }
        public UserDto GetUser(int id)
        {
            User user = _context.Users.Find(id);

            if (user == null)
            {
                throw new NotFoundException("Nie znaleziono użytkownika o podanym Id");
            }
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }
    }

}
