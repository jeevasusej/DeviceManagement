using DeviceManagement.BL.Constants;
using DeviceManagement.BL.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.BL.Contracts
{
    public interface IDeviceBL
    {
        /// <summary>
        /// Show list of devices for the admin/user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ICollection<DeviceDto>> GetDevices(Guid userId);

        /// <summary>
        /// Show the list of devices for the user
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        Task<ICollection<UserDeviceDto>> GetUserDevices(Guid userid);

        /// <summary>
        /// Show the list of user's devices for admin
        /// </summary>
        /// <param name="adminid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        Task<ICollection<DeviceDto>> GetUserDevices(Guid adminid, Guid userid);

        /// <summary>
        /// Create/Update Device
        /// </summary>
        /// <param name="device"></param>
        void UpsertDevice(DeviceDto device);

        /// <summary>
        /// Get device details
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DeviceDto> GetDevice(long id);

        /// <summary>
        /// Delete device by admin
        /// </summary>
        /// <param name="adminid"></param>
        /// <param name="id"></param>
        void DeleteDevice(Guid adminid, long id);

        /// <summary>
        /// Device request by the user
        /// User can request or cancel the request
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="deviceId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<bool> UpdateDeviceStatus(Guid userid, long deviceId, UserDeviceActionStatus status);

        /// <summary>
        /// Assign device to user by admin
        /// Device request by the admin
        /// Admin can request/approve/reject
        /// </summary>
        /// <param name="adminid"></param>
        /// <param name="userid"></param>
        /// <param name="deviceId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<bool> UpdateDeviceStatus(Guid adminid, Guid userid, long deviceId, AdminDeviceActionStatus status);
    }
}
