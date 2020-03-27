using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.Auth.Identity.User;
using BBIT.Domain.Entities.Auth.JWT;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BBIT.DAL.Context
{
    public class BBITContext : IdentityDbContext<AppUser>
    {
        public BBITContext(DbContextOptions<BBITContext> options) : base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
