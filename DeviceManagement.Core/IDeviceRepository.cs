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
        Task<bool> DeleteDevice(Guid adminId, long deviceId);
        Task<Device> UpsertDevice(Guid adminId, Device device);
        Task<Credential> UpdateDeviceCredential(Guid adminId, long deviceId, Credential credential);
        Task<bool> RemoveDeviceCredential(Guid adminId, long deviceId);
    }
}
