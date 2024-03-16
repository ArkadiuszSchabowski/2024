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
        private readonly IAccountValidation _validation;

        public AccountService(MyDbContext context, IMapper mapper, IAccountValidation validation)
        {
            _context = context;
            _mapper = mapper;
            _validation = validation;
        }
        public async Task<RegisterUserDto> RegisterUser(RegisterUserDto dto)
        {
            _validation.Validation(dto);

            using var hmac = new HMACSHA512();

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
