using DeviceManagement.Persistence.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Persistence.Contracts
{
    public interface IUser
    {
        Task<User> GetUser(string username);
        Task<bool> UserExists(string username);
        void CreateUser(User user);
        Task<User> GetUser(Guid id);
        void DeleteUser(Guid id);
        Task<ICollection<Device>> GetUserDevices();
        Task<ICollection<User>> GetUsers(Guid id, bool excludeInActive = false, bool includeAdmin = false);
        Task<ICollection<User>> GetAdmins(Guid id);
    }
}
