using api.Entities;
using api.Exceptions;
using api.Models;
using api.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace api.Services
{
    public interface IAccountService
    {
        Task<RegisterUserDto> RegisterUser(RegisterUserDto dto);
    }
    public class AccountService : IAccountService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserValidator _userValidator;

        public AccountService(MyDbContext context, IMapper mapper, IUserValidator userValidator)
        {
            _context = context;
            _mapper = mapper;
            _userValidator = userValidator;
        }
        public async Task<RegisterUserDto> RegisterUser(RegisterUserDto dto)
        {
            using var hmac = new HMACSHA512();

            _userValidator.Validation(dto);

            var checkUser = _context.Users.FirstOrDefault(x => x.UserName == dto.UserName);
            if (checkUser != null)
            {
                throw new ConflictException("Istnieje już użytkownik o takiej nazwie");
            }
            var user = new AppUser
            {
                UserName = dto.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userDto = _mapper.Map<RegisterUserDto>(user);

            return userDto;
        }
    }

}
