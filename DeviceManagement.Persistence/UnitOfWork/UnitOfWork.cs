using DeviceManagement.Core;
using DeviceManagement.Core.UnitOfWork;
using DeviceManagement.Entity;
using System.Threading.Tasks;

namespace DeviceManagement.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;

        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
