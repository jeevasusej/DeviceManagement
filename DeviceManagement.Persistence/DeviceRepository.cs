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
        public Task<bool> DeleteDevice(Guid adminId, long deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<Device> GetDevice(Guid userId, long deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Device>> GetDevices(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveDeviceCredential(Guid adminId, long deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<Credential> UpdateDeviceCredential(Guid adminId, long deviceId, Credential credential)
        {
            throw new NotImplementedException();
        }

        // To update or delete the device
        public Task<Device> UpsertDevice(Guid adminId, Device device)
        {
            throw new NotImplementedException();
        }
    }
}
