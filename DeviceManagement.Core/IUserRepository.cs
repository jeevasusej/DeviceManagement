using DeviceManagement.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManagement.Core
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(Guid userId);
        Task<User> GetUser(Guid adminId, Guid userId);
        Task<User> GetUser(string username, string password);
        Task<bool> DeleteUser(Guid adminId, Guid userId);
        Task<bool> ChangeUserState(Guid adminId, Guid userId, bool isActive);
        Task<User> RegisterUser(Guid userId, User user, string password);
        Task<User> UpdateUser(Guid adminId, Guid userId, User user);
        Task<bool> UpdateUserPassword(Guid adminId, Guid userId, string password);
        Task<Role> GetUserRole(Guid adminId, Guid userId);
        Task<bool> ChangePassword(Guid userId, string oldPassword, string newPassword);
    }
}