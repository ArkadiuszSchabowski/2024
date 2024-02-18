using _089.RestaurantTutorial.Entities;
using _089.RestaurantTutorial.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace _089.RestaurantTutorial.Service
{
    public interface IAccountService
    {
        public User CreateUser(RegisterUserDto dto);
    }
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly MyDbContext _context;

        public AccountService(IMapper mapper, IPasswordHasher<User> passwordHasher, MyDbContext context)
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _context = context;
        }
        public User CreateUser(RegisterUserDto dto)
        {
            var newUser = new User
            {
                Name = dto.Name,
                Email = dto.Email
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.HashPassword = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }
    }

}
