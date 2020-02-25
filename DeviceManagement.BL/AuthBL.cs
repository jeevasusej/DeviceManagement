using AutoMapper;
using DeviceManagement.BL.Contracts;
using DeviceManagement.BL.Dto;
using DeviceManagement.BL.Modal;
using DeviceManagement.DL.Contracts.UnitOfWork;
using DeviceManagement.DL.Enum;
using DeviceManagement.DL.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.BL
{
    public class AuthBL : IAuthBL
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AuthBL(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        private void CreatePasswordHash(string password,
            out byte[] passwordHash,
            out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password,
             byte[] passwordHash,
             byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i]) return false;

                }
            }
            return true;
        }
        private void UserValidations(User user)
        {
            if (user == null)
            {
                throw new Exception("Invalid user");
            }
        }
        public async Task<bool> ChangePassword(Guid userid, UpdatePasswordModal user)
        {
            var _user = await _uow.Users.GetUser(userid);
            UserValidations(_user);

            if (!VerifyPasswordHash(user.OldPassword, _user.PasswordHash, _user.PasswordSalt))
                throw new Exception("Invalid password");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(user.NewPassword, out passwordHash, out passwordSalt);

            _user.PasswordHash = passwordHash;
            _user.PasswordSalt = passwordSalt;

            await _uow.CompleteAsync();

            return await Task.FromResult(true);
        }
        public async Task<UserDto> CreateUser(RegisterModal user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var model = _mapper.Map<User>(user);
            model.PasswordHash = passwordHash;
            model.PasswordSalt = passwordSalt;
            model.RoleId = (byte)RoleType.User;

            _uow.Users.CreateUser(model);
            await _uow.CompleteAsync();

            return await Task.FromResult(_mapper.Map<UserDto>(model));
        }

        public async Task<UserDto> GetUser(string username, string password)
        {
            var user = await _uow.Users.GetUser(username);

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return await Task.FromResult(_mapper.Map<UserDto>(user));
        }

        public async Task<bool> UserExists(string username)
        {
            return await _uow.Users.UserExists(username);
        }
    }
}
