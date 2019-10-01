using DeviceManagement.BL.Dto;
using DeviceManagement.BL.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.BL.Contracts
{
    public interface IAuthBL
    {
        Task<UserDto> GetUser(string username, string password);
        Task<bool> UserExists(string username);
        Task<UserDto> CreateUser(RegisterModal user, string password);
        Task<bool> ChangePassword(Guid userid, UpdatePasswordModal user);
    }
}
