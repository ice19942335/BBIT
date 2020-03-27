using BBIT.DAL.Context;
using BBIT.Domain.Auth.Identity.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Services.DefaultDataInitializationServices.Auth
{
    public class IdentityInitializer
    {
      
        private readonly BBITContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(
            BBITContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            if (!await _roleManager.RoleExistsAsync(DefaultIdentity.RoleAdmin))
                await _roleManager.CreateAsync(new IdentityRole(DefaultIdentity.RoleAdmin));

            if (!await _roleManager.RoleExistsAsync(DefaultIdentity.RoleUser))
                await _roleManager.CreateAsync(new IdentityRole(DefaultIdentity.RoleUser));

            if (await _userManager.FindByEmailAsync(DefaultIdentity.DefaultAdminUserName) is null)
            {
                var guid = Guid.NewGuid();
                var admin = new AppUser
                {
                    Id = guid.ToString(),
                    UserName = DefaultIdentity.DefaultAdminUserName,
                    Email = DefaultIdentity.DefaultAdminUserName,
                    EmailConfirmed = true,
                    Name = DefaultIdentity.DefaultAdminName
                };

                var creationResult = await _userManager.CreateAsync(admin, DefaultIdentity.DefaultAdminPassword);

                if (creationResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, DefaultIdentity.RoleAdmin);
                    await _userManager.AddToRoleAsync(admin, DefaultIdentity.RoleUser);
                }
            }
        }
    }
}

