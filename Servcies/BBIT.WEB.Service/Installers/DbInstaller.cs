using BBIT.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BBIT.WEB.Service.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BBITContext>(options =>
                //options.UseSqlServer(configuration.GetConnectionString("DevelopmentConnection")));
                options.UseSqlServer(configuration.GetConnectionString("ProductionConnection")));
        }
    }
}
