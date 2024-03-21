using api.Entities;
using api.Exceptions;
using api.Models;
using api.Validators;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;

namespace api.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
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
        public void RegisterUser(RegisterUserDto dto)
        {
            _validation.Validation(dto);

            var userDto = new RegisterUserDto
            {
                UserName = dto.UserName,
                RoleId = dto.RoleId
            };

            var user = _mapper.Map<User>(userDto);

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
