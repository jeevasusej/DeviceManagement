using DeviceManagement.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManagement.Core
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers(Guid userId);
        Task<User> GetUser(string username, string password);
        Task<bool> DeleteUser(Guid adminId, Guid userId);
        Task<bool> ChangeUserState(Guid userId, bool isActive);
        Task<User> UpsertUser(Guid userId, User user, string password);
        Task<bool> IsUserExists(string username);
        Task<Role> GetUserRole(Guid adminId, Guid userId);
    }
}