using DeviceManagement.Persistence.Contracts;
using DeviceManagement.Persistence.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DeviceManagement.Persistence.Enum;

namespace DeviceManagement.Persistence
{
    public class UserRepository : IUser
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async void CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetUser(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username.Trim().ToLower());
        }

        public async Task<User> GetUser(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
        }
        public async Task<ICollection<User>> GetUsers(Guid id, bool excludeInActive = false, bool includeAdmin = false)
        {
            return await _context.Users.Where(u =>
                                ((excludeInActive && u.IsActive) || true)
                                && !u.IsDeleted
                                && ((!includeAdmin && u.RoleId == (int)RoleType.User) || true)
                                && u.Id != id)
                                .ToListAsync();
        }
        public async void DeleteUser(Guid id)
        {
            var user = await GetUser(id);
            _context.Users.Remove(user);
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(u => u.Username == username)) return true;

            return false;
        }

        public Task<ICollection<Device>> GetUserDevices()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<User>> GetAdmins(Guid id)
        {
            return await _context.Users.Where(u => u.Id != id).ToListAsync();
        }
    }
}
