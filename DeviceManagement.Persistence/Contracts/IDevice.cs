using DeviceManagement.Persistence.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Persistence.Contracts
{
    public interface IDevice
    {
        Task<ICollection<Device>> GetDevices();
        Task<ICollection<User>> GetDeviceUsers(long id);
        void CreateDevice(Device device);
        Task<Device> GetDevice(long id);
        void DeleteDevice(long id);
    }
}
