using DeviceManagement.BL.Dto;
using DeviceManagement.BL.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.BL.Contracts
{
    public interface IUserBL
    {
        /// <summary>
        /// Update user details by admin
        /// Update user profile details by user - cannot update profile 
        /// Need to use change password method to update password
        /// </summary>
        /// <param name="adminid"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> UpdateUserDetails(Guid userid, UpdateUserModel user);

        /// <summary>
        /// Get user details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserDto> GetUser(Guid id);

        /// <summary>
        /// Get user details by admin
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserDto> GetUser(Guid adminId, Guid userId);

        /// <summary>
        /// Delete a user by admin
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteUser(Guid adminId, Guid id);

        /// <summary>
        /// Get device user
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        Task<ICollection<UserDeviceDto>> GetDeviceUserAvailability(Guid adminId);

        /// <summary>
        /// Get device's user by admin
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        Task<ICollection<UserDto>> GetDeviceUsers(Guid adminId, long deviceId);

        /// <summary>
        /// Get users 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="excludeInActive"></param>
        /// <returns></returns>
        Task<ICollection<UserDto>> GetUsers(Guid adminId, bool excludeInActive = false);

        /// <summary>
        /// Get admin details
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        Task<ICollection<UserDto>> GetAdmins(Guid adminId);
    }
}
