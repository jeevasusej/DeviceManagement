using DeviceManagement.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Core
{
    public interface IUserDeviceRepository
    {
        Task<UserDevice> UpdateDeviceRequest(Guid userId, UserDevice userDevice);
        Task<UserDevice> ApproveDevice(Guid userId, long deviceId, long requestedUserId);
        Task<UserDevice> RejectDevice(Guid userId, long deviceId, long requestedUserId, string reason);
    }
}
