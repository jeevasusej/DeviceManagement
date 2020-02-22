using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DeviceManagement.BL.Contracts;
using DeviceManagement.BL.Modal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DeviceManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBL _auth;
        private readonly IConfiguration _config;

        public AuthController(IAuthBL auth, IConfiguration config)
        {
            _auth = auth;
            _config = config;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModal user)
        {
            user.Username = user.Username.Trim().ToLower();
            user.Email = user.Email.Trim().ToLower();

            var createdUser = await _auth.CreateUser(user, user.Password);
            return Ok(createdUser);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModal user)
        {
            var userDetail = await _auth.GetUser(user.Username, user.Password);
            if (userDetail == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userDetail.Id.ToString()),
                new Claim(ClaimTypes.Name, userDetail.Username),
                new Claim(ClaimTypes.GivenName, userDetail.Name),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = creds
            };

            var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateToken(tokendescriptor);

            return Ok(new {
                token = tokenhandler.WriteToken(token)
            });
        }
    }
}
