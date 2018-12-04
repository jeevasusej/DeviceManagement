using DeviceManagement.Entity;
using DeviceManagement.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Core
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetDevices(Guid userId);
        Task<Device> GetDevice(Guid userId, long deviceId);
        Task<bool> DeleteDevice(Guid userId, long deviceId);
        Task<Device> UpsertDevice(Guid userId, Device device);
        Task<Credential> UpdateDeviceCredential(Guid userId, long deviceId, Credential credential);
        Task<bool> RemoveDeviceCredential(Guid userId, long deviceId);
    }
}
