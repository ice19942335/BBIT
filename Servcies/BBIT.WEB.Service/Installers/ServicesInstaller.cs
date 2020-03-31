using Interfaces.Authentication;
using Interfaces.Flat;
using Interfaces.House;
using Interfaces.Resident;
using Interfaces.Sql.Flat;
using Interfaces.Sql.House;
using Interfaces.Sql.Resident;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Authentication;
using Services.Flat;
using Services.House;
using Services.Resident;
using Services.Sql.Flat;
using Services.Sql.House;
using Services.Sql.Tenant;

namespace BBIT.WEB.Service.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Transient -------------------------------------------------------------------------------------------------------------------
            //House services
            services.AddTransient<IHouseService, HouseService>();
            services.AddTransient<ISqlHouseService, SqlHouseService>();

            //Flat services
            services.AddTransient<IFlatService, FlatService>();
            services.AddTransient<ISqlFlatService, SqlFlatService>();

            //Tenant services
            services.AddTransient<ITenantService, TenantService>();
            services.AddTransient<ISqlTenantService, SqlTenantService>();

            //Scoped ----------------------------------------------------------------------------------------------------------------------
            //Auth services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
