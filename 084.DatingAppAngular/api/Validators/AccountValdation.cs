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
            
        }
    }

}
