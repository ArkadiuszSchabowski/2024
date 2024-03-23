using api.Entities;
using api.Exceptions;
using api.Models;
using api.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace api.Services
{
    public interface IAccountService
    {
        string Login(LoginDto dto);
        void RegisterUser(RegisterUserDto dto);
    }
    public class AccountService : IAccountService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAccountValidation _validation;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(MyDbContext context, IMapper mapper, IAccountValidation validation, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _mapper = mapper;
            _validation = validation;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            _validation.Validation(dto);

            var userDto = new RegisterUserDto
            {
                Name = dto.Name, 
                RoleId = 1
            };
            var user = _mapper.Map<User>(userDto);

            user.Password = _passwordHasher.HashPassword(user, dto.Password);
            
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public string Login(LoginDto dto)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .SingleOrDefault(u => u.Name == dto.Name);

            if(user == null)
            {
                throw new BadRequestException("Niepoprawne dane logowania");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Niepoprawne dane logowania");
            }
            var token = GenerateJWT(user);
            return token;
        }
        public string GenerateJWT(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer, claims, expires: expires, signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
