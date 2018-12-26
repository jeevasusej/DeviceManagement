using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeviceManagement.Core;
using DeviceManagement.Entity;

namespace DeviceManagement.Persistence
{
    public class UserDeviceRepository : IUserDeviceRepository
    {
        public Task<UserDevice> ApproveDevice(Guid adminId, long requestId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDevice> RejectDevice(Guid adminId, long requestId, string reason)
        {
            throw new NotImplementedException();
        }

        public Task<UserDevice> RequestDevice(Guid userId, UserDevice userDevice)
        {
            throw new NotImplementedException();
        }

        public Task<UserDevice> UpdateDeviceRequest(Guid adminId, Guid userId, UserDevice userDevice)
        {
            throw new NotImplementedException();
        }
    }
}
