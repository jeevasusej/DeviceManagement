using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using DeviceManagement.Api.Models;
using DeviceManagement.Core;
using DeviceManagement.Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeviceManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration config;

        public AuthController(IMapper mapper, IUserRepository repository, IUnitOfWork unitOfWork, IConfiguration config)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.config = config;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var user = await repository.GetUser(login.Username, login.Password);

            if (user == null)
                return Unauthorized();

            var cliams = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.Name)
                 //new Claim("Role",Input.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(cliams),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred,
                NotBefore = DateTime.Now
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
