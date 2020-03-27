using Microsoft.AspNetCore.Identity;

namespace BBIT.Domain.Entities.Auth.Identity.User
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
