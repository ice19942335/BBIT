using Interfaces.Authentication;
using Interfaces.Flat;
using Interfaces.House;
using Interfaces.Sql.Flat;
using Interfaces.Sql.House;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Authentication;
using Services.Flat;
using Services.House;
using Services.Sql.Flat;
using Services.Sql.House;

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

            //Scoped ----------------------------------------------------------------------------------------------------------------------
            //Auth services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
