using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
