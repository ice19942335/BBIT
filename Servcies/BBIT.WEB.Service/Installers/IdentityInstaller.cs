using BBIT.DAL.Context;
using BBIT.Domain.Entities.Auth.Identity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BBIT.WEB.Service.Installers
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
