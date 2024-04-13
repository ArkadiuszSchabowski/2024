using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WordMaster.Server.Exceptions;
using WordMaster.Server.Models;
using WordMaster.ServerDatabase;
using WordMaster.ServerDatabase.Entities;

namespace WordMaster.Server.Services
{
    public interface IAccountService
    {
        void CreateAccount(CreateUserDto dto);
        string Login(LoginDto dto);
    }
    public class AccountService : IAccountService
    {
        private readonly MyDbContext _context;
        private readonly IPasswordHasher<User> _hasher;

        public AccountService(MyDbContext context, IPasswordHasher<User> hasher)
        {
            _context = context;
            _hasher = hasher;
        }
        public void CreateAccount(CreateUserDto dto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == dto.Login);

            if (user != null)
            {
                throw new ConflictException("Nazwa użytkownika jest już zajęta");
            }

            var userEmail = _context.Users.FirstOrDefault(e => e.Email == dto.Email);

            if (userEmail != null)
            {
                throw new ConflictException("Taki e-mail istnieje już w bazie danych");
            }


            var newUser = new User
            {
                Login = dto.Login,
                Email = dto.Email,
                Phone = dto.Phone,
                City = dto.City,
                Country = dto.Country,
            };

            var hashedPassword = _hasher.HashPassword(newUser, dto.Password);

            newUser.HashPassword = hashedPassword;

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public string Login(LoginDto dto)
        {
            throw new NotImplementedException();
        }
    }

}
