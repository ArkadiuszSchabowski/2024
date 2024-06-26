﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WordMaster.Server.Models;
using WordMaster.Server.Services;

namespace WordMaster.Server.Controllers
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
        public ActionResult CreateAccount([FromBody] CreateUserDto dto)
        {
            _service.CreateAccount(dto);
            return Ok();
        }
        [HttpPost("login")]
        public ActionResult<LogUserDto> Login([FromBody] LoginDto dto)
        {
            string token = _service.Login(dto);

            var logUserDto = new LogUserDto()
            {
                UserName = dto.Login,
                Token = token
            };

            return Ok(logUserDto);
        }
    }
}
