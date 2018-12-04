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
        /// <summary>
        /// Admin only can approve
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <param name="requestedUserId"></param>
        /// <returns></returns>
        public Task<UserDevice> ApproveDevice(Guid userId, long deviceId, long requestedUserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Addmin only can reject 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <param name="requestedUserId"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public Task<UserDevice> RejectDevice(Guid userId, long deviceId, long requestedUserId, string reason)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Request device by the user or update the requested details
        /// Admin can update the details afer approve the device
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userDevice"></param>
        /// <returns></returns>
        public Task<UserDevice> UpdateDeviceRequest(Guid userId, UserDevice userDevice)
        {
            throw new NotImplementedException();
        }
    }
}
