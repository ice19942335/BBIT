using BBIT.DAL.Context;
using BBIT.Domain.Auth.Identity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BBIT.Authentication.WEB_Service.Installers
{
    public class IdentityInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<AppUser>(options => { options.Password.RequireNonAlphanumeric = false; })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BBITContext>();
        }
    }
}
