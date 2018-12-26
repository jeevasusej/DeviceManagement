using DeviceManagement.Core;
using DeviceManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using DeviceManagement.Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUser(string username, string password)
        {
            // TODO 
            // CHECK empty for the username and password
            var user = await context.Users
                                    .AsNoTracking()
                                    .Include(u => u.Role)
                                    .FirstOrDefaultAsync(u => u.UserName.Trim() == username.Trim());

            if (user != null)
            {
                if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return user;
            }

            return null;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<IEnumerable<User>> GetUsers(Guid adminId)
        {
            CheckAdminAccess(adminId);
            return await context.Users.AsNoTracking().Where(u => u.IsDeleted == false).ToListAsync();
        }

        public async Task<bool> DeleteUser(Guid adminId, Guid userId)
        {
            CheckAdminAccess(adminId);

            if (userId == Guid.Empty)
                throw new ValidationException("Invalid user");

            var user = await context.Users
                                 .Where(u => u.Id == adminId)
                                 .SingleAsync();

            if (user == null)
                throw new ValidationException("Invalid user");

            user.IsDeleted = true;
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeUserState(Guid adminId, Guid userId, bool isActive)
        {
            CheckAdminAccess(adminId);

            if (userId == Guid.Empty)
                throw new ValidationException("Invalid user");

            var user = await context.Users
                                .Where(u => u.Id == adminId && !u.IsDeleted)
                                .SingleAsync();

            if (user == null)
                throw new ValidationException("Invalid user");

            user.IsActive = isActive;
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<User> RegisterUser(Guid adminId, User user, string password)
        {
            // TODO : VALIDATIONS
            // when add user, check for the password empty
            // when update user, it could be empty
            CheckAdminAccess(adminId);

            ValidateUserDetails(user);

            if (string.IsNullOrWhiteSpace(password))
                throw new ValidationException("Invalid user password");

            if (string.IsNullOrWhiteSpace(user.UserName))
                throw new ValidationException("Invalid user name.");

            var _user = context.Users
                                .Where(u => u.UserName.Trim().ToLower() == user.UserName.Trim().ToLower())
                                .FirstOrDefault();

            if (_user != null)
                throw new ValidationException("User already exists.");

            _user.UserName= user.UserName;
            _user.Name = user.Name;
            _user.Email = user.Email;

            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            _user.PasswordHash = passwordHash;
            _user.PasswordSalt = passwordSalt;

            _user.IsActive = true;
            _user.IsDeleted = false;
            _user.RoleId = (byte)UserRole.User;
            await context.Users.AddAsync(_user);
            await context.SaveChangesAsync();

            return _user;
        }

        internal async Task<Role> GetUserRole(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ValidationException("Invalid user");

            var user = await context.Users
                                        .AsNoTracking()
                                        .Include(u => u.Role)
                                        .Where(u => u.Id == userId && !u.IsDeleted)
                                        .SingleAsync();

            if (user == null || user.Role == null)
                throw new ValidationException("Invalid user");

            return user.Role;
        }

        public async Task<Role> GetUserRole(Guid adminId, Guid userId)
        {
            CheckAdminAccess(adminId);

            if (userId == Guid.Empty)
                throw new ValidationException("Invalid user");

            var user = await context.Users
                            .AsNoTracking()
                            .Include(u => u.Role)
                            .Where(u => u.Id == userId && u.IsDeleted == false)
                            .SingleAsync();

            if (user == null)
                throw new InvalidOperationException("User is not found");

            return user.Role;
        }

        public async Task<bool> ChangePassword(Guid userId, string oldPassword, string newPassword)
        {
            if (userId == Guid.Empty)
                throw new ValidationException("Invalid user id");

            if (string.IsNullOrWhiteSpace(oldPassword))
                throw new ValidationException("Password should not empty");

            if (string.IsNullOrWhiteSpace(newPassword))
                throw new ValidationException("Password should not empty");

            var user = await GetUser(userId);

            if (!VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
                throw new InvalidOperationException("Your old password doesnot match.");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await context.SaveChangesAsync();

            return true;
        }

        internal Task<User> GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ValidationException("Invalid user id");

            return context.Users
                        .Where(u => u.Id == userId && !u.IsDeleted)
                        .SingleOrDefaultAsync();
        }

        public async Task<User> UpdateUser(Guid adminId, Guid userId, User user)
        {
            CheckAdminAccess(adminId);

            if (userId == Guid.Empty)
                throw new ValidationException("Invalid user");

            ValidateUserDetails(user);
            var _user = await GetUser(userId);

            _user.Name = user.Name;
            _user.Email = user.Email;

            await context.SaveChangesAsync();

            return _user;
        }

        public async Task<bool> UpdateUserPassword(Guid adminId, Guid userId, string password)
        {
            CheckAdminAccess(adminId);

            if (userId == Guid.Empty)
                throw new ValidationException("Invalid user");

            if(string.IsNullOrWhiteSpace(password))
                throw new ValidationException("Invalid password");

            var user = await GetUser(userId);

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await context.SaveChangesAsync();

            return true;
        }

        private void ValidateUserDetails(User user)
        {
            if (user == null)
                throw new ValidationException("Invalid user");

            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ValidationException("Invalid user name");

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ValidationException("Invalid user email");
        }

        public Task<User> GetUser(Guid adminId, Guid userId)
        {
            CheckAdminAccess(adminId);

            if (userId == Guid.Empty)
                throw new ValidationException("Invalid user");

            return context.Users.AsNoTracking()
                            .Where(u => u.Id == userId && !u.IsDeleted)
                            .SingleOrDefaultAsync();
        }

        internal void CheckAdminAccess(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ValidationException("Invalid user");

            var role = GetUserRole(userId);

            if (role.Id != (byte)UserRole.Admin || role.Id != (byte)UserRole.Superadmin)
                throw new UnauthorizedAccessException("Invalid user access");
        }
    }
}