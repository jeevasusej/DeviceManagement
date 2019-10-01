using DeviceManagement.Persistence.Contracts;
using DeviceManagement.Persistence.Modal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace DeviceManagement.Persistence
{
    public class DeviceRepository : IDevice
    {
        private readonly DataContext _context;

        public DeviceRepository(DataContext context)
        {
            _context = context;
        }
        public async void CreateDevice(Device device)
        {
            await _context.Devices.AddAsync(device);
        }

        public void DeleteDevice(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Device> GetDevice(long id)
        {
            return await _context.Devices.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        }

        public Task<ICollection<Device>> GetDevices()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetDeviceUsers(long id)
        {
            throw new NotImplementedException();
        }
    }
}
