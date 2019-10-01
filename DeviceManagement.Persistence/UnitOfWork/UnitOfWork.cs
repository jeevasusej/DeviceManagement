using DeviceManagement.Persistence.Contracts;
using DeviceManagement.Persistence.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dbContext;
        public UnitOfWork(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private IUser _user;
        private IDevice _device;
        public IUser Users
        {
            get
            {
                if (this._user == null)
                {
                    this._user = new UserRepository(dbContext);
                }
                return this._user;
            }
        }
        public IDevice Devices
        {
            get
            {
                if (this._device == null)
                {
                    this._device = new DeviceRepository(dbContext);
                }
                return this._device;
            }
        }
        public int Complete()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose() => dbContext.Dispose();
    }
}
