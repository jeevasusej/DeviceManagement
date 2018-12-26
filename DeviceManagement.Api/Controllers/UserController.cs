using AutoMapper;
using DeviceManagement.Api.Models;
using DeviceManagement.Core;
using DeviceManagement.Core.UnitOfWork;
using DeviceManagement.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UserController(IMapper mapper, IUserRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet("GetUsers")]
        public async Task<IEnumerable<UserModel>> Get()
        {
            var users = await repository.GetUsers(Guid.NewGuid());
            return mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(RegisterModel model)
        {
            // TODO VALIDATION - CHECK NULL VALUES
            model.Username = model.Username.ToLower();

            var user = mapper.Map<RegisterModel, User>(model);
            var createdUser = await repository.RegisterUser(Guid.NewGuid(), user, model.Password);
            return Ok(mapper.Map<User, UserModel>(createdUser));
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(PasswordModel model)
        {
            // TODO VALIDATION - CHECK NULL VALUES

            //var user = mapper.Map<RegisterModel, User>(model);
            var createdUser = await repository.ChangePassword(Guid.NewGuid(), model.OldPassword, model.NewPassword);
            return Ok();
        }
    }
}