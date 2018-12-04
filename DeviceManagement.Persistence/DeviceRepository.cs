using DeviceManagement.Core;
using DeviceManagement.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Persistence
{
    public class DeviceRepository : IDeviceRepository
    {
        /// <summary>
        /// Delete device details by admin
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public Task<bool> DeleteDevice(Guid userId, long deviceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get device details by admin
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public Task<Device> GetDevice(Guid userId, long deviceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get devices by admin/user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<IEnumerable<Device>> GetDevices(Guid userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove Device Credentials by admin
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <param name="credential"></param>
        /// <returns></returns>
        public Task<bool> RemoveDeviceCredential(Guid userId, long deviceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update device credentials
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <param name="credential"></param>
        /// <returns></returns>
        public Task<Credential> UpdateDeviceCredential(Guid userId, long deviceId, Credential credential)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update/Add device
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        public Task<Device> UpsertDevice(Guid userId, Device device)
        {
            throw new NotImplementedException();
        }
    }
}
