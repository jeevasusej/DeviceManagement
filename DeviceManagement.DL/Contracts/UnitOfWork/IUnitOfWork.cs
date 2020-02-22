using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.DL.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUser Users { get; }
        Task<int> CompleteAsync();
        int Complete();
    }
}
