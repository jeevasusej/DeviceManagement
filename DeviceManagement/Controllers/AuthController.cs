using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DeviceManagement.BL.Contracts;
using DeviceManagement.BL.Modal;
using DeviceManagement.Modal;
using DeviceManagement.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DeviceManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBL _auth;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        public readonly IDataProtector protector;

        public AuthController(IAuthBL auth, IConfiguration config, ITokenService tokenService, IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeString dataProtectionPurposeString)
        {
            _auth = auth;
            _config = config;
            _tokenService = tokenService;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeString.Key);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModal user)
        {
            //throw new Exception("serilog");
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
                new Claim(ClaimTypes.NameIdentifier, protector.Protect(userDetail.Id.ToString())),
                new Claim(ClaimTypes.Name, userDetail.Username),
                new Claim(ClaimTypes.GivenName, userDetail.Name),
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);

            return Ok(new {
                token = accessToken
            });
        }
    }
}
