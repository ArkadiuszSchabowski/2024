using api.Entities;
using api.Exceptions;
using api.Models;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegisterUserDto>> Register(RegisterUserDto dto)
        {
            await _service.RegisterUser(dto);
            return Ok("Zarejestrowano pomyślnie");
        }
        [HttpPost("login")]
        public ActionResult Login(LoginDto dto)
        {
            _service.Login(dto);

            return Ok();
        }

    }
}
