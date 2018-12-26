using DeviceManagement.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Core
{
    public interface IUserDeviceRepository
    {
        Task<UserDevice> RequestDevice(Guid userId, UserDevice userDevice);
        Task<UserDevice> UpdateDeviceRequest(Guid adminId, Guid userId, UserDevice userDevice);
        Task<UserDevice> ApproveDevice(Guid adminId, long requestId);
        Task<UserDevice> RejectDevice(Guid adminId, long requestId, string reason);
    }
}
