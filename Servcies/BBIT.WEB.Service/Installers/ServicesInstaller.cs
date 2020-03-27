using Interfaces.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Authentication;

namespace BBIT.WEB.Service.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Scoped
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
