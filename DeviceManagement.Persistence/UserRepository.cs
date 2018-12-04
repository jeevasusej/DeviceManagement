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

        public async Task<bool> IsUserExists(string username)
        {
            // TODO
            // VALIDATION - CHECK EMPTY

            if (await context.Users.AnyAsync(u => u.UserName.Trim() == username.Trim()))
                return true;

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<List<User>> GetUsers(Guid userId)
        {
            return await context.Users.Where(u => u.IsDeleted == false).ToListAsync();
        }

        public Task<bool> DeleteUser(Guid adminId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeUserState(Guid userId, bool isActive)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpsertUser(Guid userId, User user, string password)
        {
             // TODO : VALIDATIONS
            // Empty for Username, Password, Name and Email
            // Length for username, password, name and email
            // Admin only can add a user
            // when add user, check for the password empty
            // when update user, it could be empty

            byte[] passwordHash, passwordSalt;

            if (await IsUserExists(user.UserName))
                throw new Exception("User name is exists.");

            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            user.IsActive = true;
            user.IsDeleted = false;
            user.RoleId = (byte)UserRole.User;
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        internal Task<Role> GetUserRole(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetUserRole(Guid adminId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}