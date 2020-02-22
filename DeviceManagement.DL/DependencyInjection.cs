using DeviceManagement.DL.Contracts;
using DeviceManagement.DL.Contracts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceManagement.DL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDLDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DeviceManagement")));

            services.AddScoped<IDevice, DeviceRepository>();
            services.AddScoped<IUser, UserRepository>();

            // Inject unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
           
            return services;
        }
    }
}
