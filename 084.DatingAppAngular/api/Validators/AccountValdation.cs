using api.Exceptions;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Validators
{
    public interface IAccountValidation
    {
        void Validation(RegisterUserDto dto);
    }
    public class AccountValdation : IAccountValidation
    {
        private readonly MyDbContext _context;

        public AccountValdation(MyDbContext context)
        {
            _context = context;
        }
        public void Validation(RegisterUserDto dto)
        {
            var checkUser = _context.Users.FirstOrDefault(x => x.Name == dto.Name);
            if (checkUser != null)
            {
                throw new ConflictException("Istnieje już użytkownik o takiej nazwie");
            }

            if (dto.Name.Length < 4)
            {
                throw new BadRequestException("Nazwa użytkownika powinna skladac sie z conajmniej czterech znaków");
            }
            if(dto.Password.Length < 4)
            {
                throw new BadRequestException("Haslo użytkownika powinno skladac sie z conajmniej czterech znaków");
            }
            if(dto.Password != dto.RepeatPassword)
            {
                throw new BadRequestException("Hasła nie są zgodne");
            }
        }
    }

}
